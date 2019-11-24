using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_DynamicList.Data
{
    public class PageItemService
    {
        private List<PageItem> PageItems = new List<PageItem>()
        {
            new PageItem()
            {
                LineOrder = 0,
                Data = "This is line 1",
                HasEdit = false
            },
            new PageItem()
            {
                LineOrder = 1,
                Data = "This is line 2",
                HasEdit = false
            },
            new PageItem()
            {
                LineOrder = 2,
                Data = "This is line 3",
                HasEdit = false
            },
            new PageItem()
            {
                LineOrder = 3,
                Data = "This is line 4",
                HasEdit = false
            }
        };

        public List<PageItem> GetPages()
        {
            List<PageItem> PageItems = null;

            PageItems = this.PageItems;

            return PageItems.OrderBy(x => x.LineOrder).ToList();
        }

        public List<PageItem> AddAction(int position, string action, string release)
        {
            var itemsAfterPosition = PageItems.Where(x => x.LineOrder > position).OrderBy( x => x.LineOrder).ToList();

            foreach (var lineItem in itemsAfterPosition)
            {
                lineItem.LineOrder += 1;
            }

            var newItem = new PageItem()
            {
                LineOrder = position + 1,
                Data = "new",
                Action = action,
                Release = release
            };

            PageItems.Add(newItem);

            var modifyLine = PageItems.Where(x => x.LineOrder == position).FirstOrDefault();
            modifyLine.HasEdit = true;

            return PageItems.OrderBy(x => x.LineOrder).ToList();
        }

        public List<PageItem> RemoveAction(int lineId)
        {
            var removeLine = PageItems.Where(x => x.LineOrder == lineId).FirstOrDefault();
            PageItems.Remove(removeLine);

            var patchLine = PageItems.Where(x => x.LineOrder == lineId - 1).FirstOrDefault();
            patchLine.HasEdit = false;

            int i = 0;
            foreach(var item in PageItems.OrderBy(x=>x.LineOrder))
            {
                item.LineOrder = i;
                i += 1;
            }

            return PageItems.OrderBy(x => x.LineOrder).ToList();
        }
    }
}
