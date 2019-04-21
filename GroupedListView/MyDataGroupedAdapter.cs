using System.Collections.Generic;
using System.Linq;
using Android.Support.V7.Widget;
using Android.Views;

namespace GroupedListView
{
    public class MyDataGroupedAdapter : RecyclerView.Adapter
    {
        public const int HeaderViewId = 1;

        public const int ItemViewId = 2;

        private readonly IEnumerable<IListItem> _items;

        public MyDataGroupedAdapter(IEnumerable<MyData> items)
        {
            var groupedData = items.GroupBy(x => x.Country)
                                   .OrderBy(a => a.Key)
                                   .ToList();

            var roma = new List<IListItem>();
            foreach (var vns in groupedData)
            {
                roma.Add(new HeaderListIem(vns.Key));
                roma.AddRange(vns.Select(d => new ListItem(d)));
            }

            _items = roma ?? Enumerable.Empty<IListItem>();
         }

        public override int ItemCount => _items?.Count() ?? 0;

        public override int GetItemViewType(int position)
        {
            var item = _items.ElementAtOrDefault(position);
            return item.GetViewType();
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            switch (holder.ItemViewType)
            {
                case ItemViewId:
                    var itemViewHolder = (MyDataViewHolder)holder;
                    var listItem = _items.ElementAtOrDefault(position) as ListItem;
                    itemViewHolder.Title.Text = listItem.City;
                    itemViewHolder.Detail.Text = $"{listItem.Population:N0}";
                    break;
                case HeaderViewId:
                    var headerViewHolder = (MyDataHeaderViewHolder)holder;
                    var headerItem = _items.ElementAtOrDefault(position) as HeaderListIem;
                    headerViewHolder.HeaderTextView.Text = headerItem.Country;
                    break;
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var inflater = LayoutInflater.From(parent.Context);
            RecyclerView.ViewHolder viewHolder = null;

            switch (viewType)
            {
                case ItemViewId:
                    var view = inflater.Inflate(Resource.Layout.data_item_layout, parent, false);
                    viewHolder = new MyDataViewHolder(view);
                        break;
                case HeaderViewId:
                    var headerView = inflater.Inflate(Resource.Layout.mydata_header_layout, parent, false);
                    viewHolder = new MyDataHeaderViewHolder(headerView);
                    break;
            }

            return viewHolder;
        }
    }

    public interface IListItem
    {
        int GetViewType(); 
    }

    public class HeaderListIem : IListItem
    {
        public string Country { get; set; }

        public HeaderListIem(string country)
        {
            Country = country;
        }

        public int GetViewType()
        {
            return MyDataGroupedAdapter.HeaderViewId;
        }
    }

    public class ListItem : IListItem
    {
        public string City { get; set; }

        public int Population { get; set; }

        public ListItem(MyData data)
        {
            City = data?.City;
            Population = data?.Population ?? 0;
        }

        public int GetViewType()
        {
            return MyDataGroupedAdapter.ItemViewId;
        }
    }
}
