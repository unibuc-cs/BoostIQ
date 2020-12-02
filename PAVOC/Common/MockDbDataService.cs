using System;
using PAVOC.DataModel.Models;
using PAVOC.DataModel.Repository.Interface;
using PAVOC.DataModel.UnitOfWork;

namespace PAVOC.Common
{
    public class MockDbDataService
    {
        public static void Fill()
        {
            FillUsers();
            FillCategories();
            FillLearnLevels();
        }

        private static void FillUsers()
        {
            using(var uow = new UnitOfWork())
            {
                var repo = uow.GetRepository<IUserRepository>();
                var user = new UserEntity()
                {
                    Email = "user@gmail.com",
                    Username = "user",
                    Password = "user",
                    PointsLearn = 0,
                    PointsPlay = 0
                };
                repo.Add(user);
                uow.Save();
            }
        }

        private static void FillCategories()
        {
            using (var uow = new UnitOfWork())
            {
                var repo = uow.GetRepository<ICategoryRepository>();

                var historyCategory = new CategoryEntity()
                {
                    Name = "History"
                };

                var geographyCategory = new CategoryEntity()
                {
                    Name = "Geography"
                };

                var sportsCategory = new CategoryEntity()
                {
                    Name = "Sports"
                };

                repo.Add(historyCategory);
                repo.Add(geographyCategory);
                repo.Add(sportsCategory);

                uow.Save();
            }
        }

        private static void FillLearnLevels()
        {
            using (var uow = new UnitOfWork())
            {
                var categoryRepository = uow.GetRepository<ICategoryRepository>();

                var historyCategory = categoryRepository.GetCategoryByName("History");

                var learnLevel1History = new LearnLevelEntity()
                {
                    LearnLevelNumber = 1,
                    //TODO Petros -> change these 2 lines
                    Image = "img",
                    Text = "First text"
                };
                historyCategory.LearnLevels.Add(learnLevel1History);

                var learnQuestion1LearnLevel1History = new LearnQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "Intrebarea 1?",
                };
                learnLevel1History.LearnQuestions.Add(learnQuestion1LearnLevel1History);

                var learnQuestionAnswer1Question1LearnLevel1History = new LearnQuestionAnswerEntity()
                {
                    Text = "Yes",
                    IsCorrect = true
                };
                learnQuestion1LearnLevel1History.LearnQuestionAnswers.Add(learnQuestionAnswer1Question1LearnLevel1History);

                var learnQuestionAnswer2Question1LearnLevel1History = new LearnQuestionAnswerEntity()
                {
                    Text = "No",
                    IsCorrect = false
                };
                learnQuestion1LearnLevel1History.LearnQuestionAnswers.Add(learnQuestionAnswer2Question1LearnLevel1History);


                var learnQuestion2LearnLevel1History = new LearnQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "Intrebarea 2?",
                };
                learnLevel1History.LearnQuestions.Add(learnQuestion2LearnLevel1History);

                var learnQuestionAnswer1Question2LearnLevel1History = new LearnQuestionAnswerEntity()
                {
                    Text = "Yes",
                    IsCorrect = true
                };
                learnQuestion2LearnLevel1History.LearnQuestionAnswers.Add(learnQuestionAnswer1Question2LearnLevel1History);

                var learnQuestionAnswer2Question2LearnLevel1History = new LearnQuestionAnswerEntity()
                {
                    Text = "No",
                    IsCorrect = false
                };
                learnQuestion2LearnLevel1History.LearnQuestionAnswers.Add(learnQuestionAnswer2Question2LearnLevel1History);


                categoryRepository.Update(historyCategory);

                uow.Save();
            }
        }
    }
}
