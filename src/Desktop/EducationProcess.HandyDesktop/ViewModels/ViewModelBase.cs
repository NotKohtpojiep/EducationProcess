using System.Collections.Generic;
using GalaSoft.MvvmLight;

namespace EducationProcess.HandyDesktop.ViewModels
{
    public class ViewModelBase<T> : ViewModelBase
    {
        private IList<T> _dataList;

        public IList<T> DataList
        {
            get => _dataList;
            set => Set(ref _dataList, value);
        }
    }
}
