using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace GroupedListView
{
    public class MyDataViewHolder : RecyclerView.ViewHolder
    {
        public TextView Title { get; private set; }

        public TextView Detail { get; private set; }

        public MyDataViewHolder(View itemView) : base(itemView)
        {
            Title = itemView.FindViewById<TextView>(Resource.Id.tv_title);
            Detail = itemView.FindViewById<TextView>(Resource.Id.tv_details);
        }
    }
}
