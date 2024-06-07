using DigitasChallenge.BLL.Models;

namespace DigitasChallenge.BLL.Helpers
{
    public static class InsertsHelper
    {
        public static List<SimpleTasksModel> GenerateInitialData()
        {
            var listModel = new List<SimpleTasksModel>() 
            { 
                new SimpleTasksModel 
                { 
                    Name = "Limpar a casa", 
                    Description = "Passar pano, tirar pó e varrer", 
                    Starts = DateTime.Now.AddDays(2).Date,
                    Ends = DateTime.Now.AddDays(4).Date
                },
                new SimpleTasksModel
                {
                    Name = "Estudar para o concurso",
                    Description = "Ler e fazer os exercícios",
                    Starts = DateTime.Now.AddDays(-1).Date,
                    Ends = DateTime.Now.AddDays(3).Date
                },
                new SimpleTasksModel
                {
                    Name = "Fazer o IR",
                    Description = "Coletar os holerites e lançar",
                    Starts = DateTime.Now.AddDays(-3).Date,
                    Ends = DateTime.Now.AddDays(-2).Date
                },
                new SimpleTasksModel
                {
                    Name = "Preparar o jantar para o feriado",
                    Description = "Comprar o ingredientes e seguir a receita proposta",
                    Starts = DateTime.Now.Date,
                    Ends = DateTime.Now.AddDays(1).Date
                },
                new SimpleTasksModel
                {
                    Name = "Ir ao banco",
                    Description = "Levar o comprovante de residencia e foto 3x4",
                    Starts = DateTime.Now.AddDays(4).Date,
                    Ends = DateTime.Now.AddDays(4).Date
                },
                new SimpleTasksModel
                {
                    Name = "Levar o cachorro no petshop",
                    Description = "Fazer banho, tosa e aplicar produtos antipulgas",
                    Starts = DateTime.Now.AddDays(-2).Date,
                    Ends = DateTime.Now.AddDays(-1).Date
                },
            };

            return listModel;
        }
    }
}
