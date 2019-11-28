using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoConfig;
using Model.EntityFramework;
using Model.ViewModel;

namespace Model.Dao
{
    public class ContentDao
    {
        OnlineShopDbContext db = null;
        public ContentDao()
        {
            db = new OnlineShopDbContext();
        }

        public List<ContentViewModel> GetListContent()
        {
            List<Content> Content = db.Contents.ToList();
            List<Tag> tags = db.Tags.ToList();
            List<ContentTag> contentTags = db.ContentTags.ToList();
            List<ContentViewModel> userViewModel = new List<ContentViewModel>();
            for (int i = 1; i <= Content.Count(); i++)
            {
                var listtag = from a in contentTags
                                    join c in tags on a.TagID equals c.ID
                                    where a.ContentID == i
                                    select new Tag
                                    {
                                        ID = c.ID,
                                        Name=c.Name
                                    };
                ContentViewModel contentView = new ContentViewModel();
                Content contents = db.Contents.Find(i);
                contentView.content = contents;
                foreach (Tag item in listtag)
                {
                    contentView.tag = new List<Tag>();
                    contentView.tag.Add(item);
                }
                userViewModel.Add(contentView);
            }
            return userViewModel.OrderBy(x => x.content.CreatedDate).ToList();

    }
}
}
