using AutoMapper;
using DigitasChallenge.BLL.Helpers;
using DigitasChallenge.BLL.Models;
using DigitasChallenge.BLL.Services.Interfaces;
using DigitasChallenge.BLL.Validators.Interfaces;
using DigitasChallenge.DAL.Entities;
using DigitasChallenge.DAL.Repositories.Interfaces;
using DigitasChallenge.Enums;

namespace DigitasChallenge.BLL.Services
{
    public class TasksService : ITasksService
    {
        private readonly IMapper _mapper;
        private readonly ITasksRepository _repository;
        private readonly ITasksValidator _validator;

        public TasksService(IMapper mapper, ITasksRepository repository, ITasksValidator validator)
        {
            _mapper = mapper;
            _repository = repository;
            _validator = validator;
        }

        private string SetStatus(DateTime starts, DateTime ends, string status = "")
        {
            var currentDate = DateTime.Now.Date;

            if (string.IsNullOrWhiteSpace(status))
            {
                if (starts > currentDate && starts < ends)
                {
                    status = Status.Draft.ToString();
                }
                else if (starts <= currentDate && starts <= ends && currentDate <= ends)
                {
                    status = Status.Doing.ToString();
                }
                else if (starts <= currentDate && starts <= ends && currentDate > ends)
                {
                    status = Status.Delayed.ToString();
                }
                else
                {
                    status = Status.Done.ToString();
                }
            }

            return status;
        }

        #region 'Usual Methods'
        public bool DoesNotHaveTheSameName(int id, string name)
        {
            return _repository.DoesNotHaveTheSameName(id, name);
        }

        public IEnumerable<CompleteTasksModel> GetAll()
        {
            var list = _repository.GetAll().Where(t => !t.Status.Equals(Status.Deleted)).ToList();

            var model = _mapper.Map<List<CompleteTasksModel>>(list);

            model.ForEach(m => m.Status = SetStatus(m.Starts, m.Ends, m.Status));

            return model;
        }

        public CompleteTasksModel GetById(int id)
        {
            var entity = _repository.GetById(id);

            if (entity != null)
            {
                var model = _mapper.Map<CompleteTasksModel>(entity);

                model.Status = SetStatus(model.Starts, model.Ends, model.Status);

                return model;
            }
            else
            {
                throw new Exception("There is no record with this id.");
            }            
        }        

        public void Add(SimpleTasksModel model)
        {
            _validator.ValidateTask(model, DoesNotHaveTheSameName(0, model.Name));

            var entity = _mapper.Map<Tasks>(model);

            entity.Starts = entity.Starts.Date;
            entity.Ends = entity.Ends.Date;
            entity.Status = Enum.Parse<Status>(SetStatus(entity.Starts, entity.Ends));

            _repository.Add(entity);
        }

        public void Update(CompleteTasksModel model)
        {
            _validator.ValidateTask(model, DoesNotHaveTheSameName(model.Id, model.Name));

            var entity = _mapper.Map<Tasks>(model);

            entity.Starts = entity.Starts.Date;
            entity.Ends = entity.Ends.Date;
            entity.Status = Enum.Parse<Status>(SetStatus(entity.Starts, entity.Ends, model.Status));

            _repository.Update(entity);
        }

        public void Remove(int id)
        {
            var entity = _repository.GetById(id);

            entity.Status = Status.Deleted;

            _repository.Update(entity);
        } 
        #endregion

        #region 'Mock Methods'
        public void AddAll()
        {
            var areThereRecords = _repository.GetAll().Any();

            if (!areThereRecords)
            {
                var listModel = InsertsHelper.GenerateInitialData();

                foreach (var item in listModel)
                {
                    Add(item);
                }
            }
            else
            {
                throw new Exception("There are previous records in the database.");
            }
        }

        public void RemoveAll()
        {
            var listEntity = _repository.GetAll();

            if (listEntity.Any())
            {
                foreach (var item in listEntity)
                {
                    _repository.Remove(item);
                }
            }
            else
            {
                throw new Exception("There are no records in the database.");
            }
        }        
        #endregion
    }
}