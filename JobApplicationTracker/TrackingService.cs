using JobApplicationTracker.Infrastructure.Persistence;
using JobApplicationTracker.Mappers;
using JobApplicationTracker.ViewModel;
using System.Collections.ObjectModel;

namespace JobApplicationTracker
{
    public class TrackingService
    {
        private readonly LocalDbService localDbService;
        private readonly MainViewModel mainViewModel;

        public TrackingService(MainViewModel mainViewModel, LocalDbService localDbService)
        {
            this.localDbService = localDbService;
            this.mainViewModel = mainViewModel;
        }

        public async Task Initialize()
        {
            await GetState();
            await GetApplicants();
            await SetApplicant(mainViewModel.CurrentState?.ApplicantId);
        }
            
        private async Task GetState()
        {
            var state = await localDbService.GetState();
            mainViewModel.CurrentState = state.ToViewModel();
        }

        public async Task GetApplicants()
        {
            var applicants = await localDbService.GetApplicants();
            mainViewModel.Applicants = new ObservableCollection<ViewModel.Applicant>(applicants.Select(a => a.ToViewModel()));
        }

        public async Task SetApplicant(Guid? id)
        {
            mainViewModel.Applicant = mainViewModel.Applicants.Single(a => a.Id == id);
            await localDbService.SetState(new Infrastructure.Persistence.State { ApplicantId = mainViewModel.Applicant.Id });
        }

        public async Task SaveApplicant()
        {
            if (mainViewModel.Applicant != null)
            {
                if (mainViewModel.Applicant.Id == Guid.Empty)
                {
                    await localDbService.Create(
                        new Infrastructure.Persistence.Applicant
                        {
                            Id = Guid.NewGuid(),
                            FirstName = mainViewModel.Applicant.FirstName,
                            MiddleName = mainViewModel.Applicant.MiddleName,
                            LastName = mainViewModel.Applicant.LastName,
                            EmailAddress = mainViewModel.Applicant.EmailAddress,
                            LinkedInUri = mainViewModel.Applicant.LinkedInUri,
                        });
                    await localDbService.SetState(new Infrastructure.Persistence.State { ApplicantId = mainViewModel.Applicant.Id });
                }
                else
                {
                    await localDbService.Update(
                        new Infrastructure.Persistence.Applicant
                        {
                            Id = mainViewModel.Applicant.Id,
                            FirstName = mainViewModel.Applicant.FirstName,
                            MiddleName = mainViewModel.Applicant.MiddleName,
                            LastName = mainViewModel.Applicant.LastName,
                            EmailAddress = mainViewModel.Applicant.EmailAddress,
                            LinkedInUri = mainViewModel.Applicant.LinkedInUri,
                        });
                }
            }
            else
            {
                throw new Exception("There is no current applicant set. Applicant is null.");
            }
        }
    }
}
