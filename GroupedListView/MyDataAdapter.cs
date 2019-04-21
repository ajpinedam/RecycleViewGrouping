using System.Collections.Generic;
using System.Linq;
using Android.Support.V7.Widget;
using Android.Views;

namespace GroupedListView
{
    public class MyDataAdapter : RecyclerView.Adapter
    {
        private readonly IEnumerable<MyData> _items;

        public MyDataAdapter(IEnumerable<MyData> items)
        {
            _items = items ?? Enumerable.Empty<MyData>();
        }

        public override int ItemCount => _items?.Count() ?? 0;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var vh = holder as MyDataViewHolder;

            var item = _items.ElementAtOrDefault(position);

            vh.Title.Text = item.City;
            vh.Detail.Text = $"{item.Population:N0}";
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.data_item_layout, parent, false);
            var viewHolder = new MyDataViewHolder(view);

            return viewHolder;
        }
    }
}
