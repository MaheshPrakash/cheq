#pragma warning disable
﻿using System;
using System.Activities.Presentation.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Dev2.Activities.Utils;
using Dev2.Common;
using Dev2.Common.Interfaces;
using Dev2.Common.Interfaces.ServerProxyLayer;
using Dev2.Common.Interfaces.ToolBase;
using Dev2.Studio.Core.Activities.Utils;


namespace Dev2.Activities.Designers2.Core
{
    public class WebPostInputRegion : IWebPostInputArea
    {
        readonly ModelItem _modelItem;
        readonly ISourceToolRegion<IWebServiceSource> _source;
        string _queryString;
        string _requestUrl;
        ObservableCollection<INameValue> _headers;
        bool _isEnabled;
        string _postData;

        public WebPostInputRegion()
        {
            ToolRegionName = "PostInputRegion";
        }

        public WebPostInputRegion(ModelItem modelItem, ISourceToolRegion<IWebServiceSource> source)
        {
            ToolRegionName = "PostInputRegion";
            _modelItem = modelItem;
            _source = source;
            _source.SomethingChanged += SourceOnSomethingChanged;
            IsEnabled = false;
            SetupHeaders(modelItem);
            if (source?.SelectedSource != null)
            {
                RequestUrl = source.SelectedSource.HostName;
                IsEnabled = true;
            }
        }
        void SourceOnSomethingChanged(object sender, IToolRegion args)
        {

            if (_source?.SelectedSource != null)
            {
                RequestUrl = _source.SelectedSource.HostName;
                QueryString = _source.SelectedSource.DefaultQuery;
                PostData = string.Empty;
                Headers.Clear();
                Headers.Add(new ObservableAwareNameValue(Headers, s =>
                {
                    _modelItem.SetProperty("Headers",
                        _headers.Select(a => new NameValue(a.Name, a.Value) as INameValue).ToList());
                }));
                IsEnabled = true;
            }

            OnPropertyChanged(@"IsEnabled");
        }
        void SetupHeaders(ModelItem modelItem)
        {
            var existing = modelItem.GetProperty<IList<INameValue>>("Headers");
            var headerCollection = new ObservableCollection<INameValue>(existing ?? new List<INameValue>());
            headerCollection.CollectionChanged += HeaderCollectionOnCollectionChanged;
            Headers = headerCollection;

            if (Headers.Count == 0)
            {
                Headers.Add(new ObservableAwareNameValue(Headers, s =>
                {
                    _modelItem.SetProperty("Headers",
                        _headers.Select(a => new NameValue(a.Name, a.Value) as INameValue).ToList());
                }));
            }
            else
            {
                var nameValue = Headers.Last();
                if (!string.IsNullOrWhiteSpace(nameValue.Name) || !string.IsNullOrWhiteSpace(nameValue.Value))
                {
                    Headers.Add(new ObservableAwareNameValue(Headers, s =>
                    {
                        _modelItem.SetProperty("Headers",
                            _headers.Select(a => new NameValue(a.Name, a.Value) as INameValue).ToList());
                    }));
                }
            }
        }

        void HeaderCollectionOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            _modelItem.SetProperty("Headers", _headers.Select(a => new NameValue(a.Name, a.Value) as INameValue).ToList());
        }

        #region Implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Implementation of IToolRegion

        public string ToolRegionName { get; set; }
        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }

        public IList<IToolRegion> Dependants { get; set; }

        public IToolRegion CloneRegion()
        {
            var headers2 = new ObservableCollection<INameValue>();
            foreach (var nameValue in Headers)
            {
                headers2.Add(new NameValue(nameValue.Name, nameValue.Value));
            }
            return new WebPostInputRegion(_modelItem, _source)
            {
                Headers = headers2,
                PostData = PostData,
                QueryString = QueryString,
                RequestUrl = RequestUrl,
                IsEnabled = IsEnabled
            } as IToolRegion;
        }

        public void RestoreRegion(IToolRegion toRestore)
        {
            if (toRestore is WebPostInputRegion region)
            {
                IsEnabled = region.IsEnabled;
                PostData = region.PostData;
                QueryString = region.QueryString;
                RequestUrl = region.RequestUrl;
                Headers.Clear();
                Headers.Add(new ObservableAwareNameValue(Headers, s =>
                {
                    _modelItem.SetProperty("Headers",
                        _headers.Select(a => new NameValue(a.Name, a.Value) as INameValue).ToList());
                }));
                if (region.Headers != null)
                {
                    foreach (var nameValue in region.Headers)
                    {
                        Headers.Add(new ObservableAwareNameValue(Headers, s =>
                        {
                            _modelItem.SetProperty("Headers",
                                _headers.Select(a => new NameValue(a.Name, a.Value) as INameValue).ToList());
                        })
                        { Name = nameValue.Name, Value = nameValue.Value });
                    }
                    Headers.Remove(Headers.First());
                }
            }
        }

        public EventHandler<List<string>> ErrorsHandler
        {
            get;
            set;
        }

        public IList<string> Errors
        {
            get
            {
                IList<string> errors = new List<string>();
                return errors;
            }
        }

        #endregion

        #region Implementation of IWebPostInputArea

        public string PostData
        {
            get
            {
                return _modelItem.GetProperty<string>("PostData") ?? string.Empty;
            }
            set
            {
                _postData = value ?? string.Empty;
                _modelItem.SetProperty("PostData", value ?? string.Empty);
                OnPropertyChanged();
            }
        }
        public string QueryString
        {
            get
            {
                return _modelItem.GetProperty<string>("QueryString") ?? string.Empty;
            }
            set
            {
                _queryString = value ?? string.Empty;
                _modelItem.SetProperty("QueryString", value ?? string.Empty);
                OnPropertyChanged();
            }
        }
        public string RequestUrl
        {
            get
            {
                return _requestUrl;
            }
            set
            {
                _requestUrl = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<INameValue> Headers
        {
            get
            {
                return _headers;
            }
            set
            {
                _headers = value;
                _modelItem.SetProperty("Headers", value.ToList());
                OnPropertyChanged();
            }
        }

        #endregion
    }
}
