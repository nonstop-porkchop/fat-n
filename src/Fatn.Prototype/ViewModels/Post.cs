using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Fatn.Prototype.ViewModels
{
    public class Post : INotifyPropertyChanged
    {
        private string _content;
        private CommunityMember _poster;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Content
        {
            get => _content;
            set
            {
                if (value == _content) return;
                _content = value;
                OnPropertyChanged();
            }
        }

        public CommunityMember Poster
        {
            get => _poster;
            set
            {
                if (Equals(value, _poster)) return;
                _poster = value;
                OnPropertyChanged();
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class CommunityMember : INotifyPropertyChanged
    {
        private string _nickname;
        private Uri _profileImage;

        public string Nickname
        {
            get => _nickname;
            set
            {
                if (value == _nickname) return;
                _nickname = value;
                OnPropertyChanged();
            }
        }

        public Uri ProfileImage
        {
            get => _profileImage;
            set
            {
                if (Equals(value, _profileImage)) return;
                _profileImage = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}