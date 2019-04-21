using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace GroupedListView
{
    public class MyDataHeaderViewHolder : RecyclerView.ViewHolder
    {
        public TextView HeaderTextView { get; private set;}

        public MyDataHeaderViewHolder(View itemView) : base(itemView)
        {
            HeaderTextView = itemView.FindViewById<TextView>(Resource.Id.tv_country_header);
        }
    }
}
