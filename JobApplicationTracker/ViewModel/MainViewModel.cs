using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace JobApplicationTracker.ViewModel
{
    public class MainViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public State? CurrentState { get; set; }

        private Applicant? applicant;
        public Applicant? Applicant
        {
            get
            {
                return applicant;
            }
            set
            {
                if (applicant != value)
                {
                    applicant = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<Applicant>? applicants;
        public ObservableCollection<Applicant> Applicants
        {
            get
            {
                return applicants;
            }
            set
            {
                if (applicants != value)
                {
                    applicants = value;
                    OnPropertyChanged();
                }
            }
        }

        private JobApplication? jobApplication;
        public JobApplication? JobApplication
        {
            get
            {
                return jobApplication;
            }
            set
            {
                if (jobApplication != value)
                {
                    jobApplication = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<JobApplication>? jobApplications;
        public ObservableCollection<JobApplication> JobApplications
        {
            get
            {
                return jobApplications;
            }
            set
            {
                if (jobApplications != value)
                {
                    jobApplications = value;
                    OnPropertyChanged();
                }
            }
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
