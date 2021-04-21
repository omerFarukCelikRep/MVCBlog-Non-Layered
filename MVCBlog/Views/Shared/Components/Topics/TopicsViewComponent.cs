using Microsoft.AspNetCore.Mvc;
using MVCBlog.Repositories.Abstract;
using MVCBlog.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBlog.Views.Shared.Components.Topics
{
    public class TopicsViewComponent : ViewComponent
    {
        private readonly TopicRepository _topicRepository;

        public TopicsViewComponent(ITopicRepository topicRepository)
        {
            _topicRepository = (TopicRepository)topicRepository;
        }

        public IViewComponentResult Invoke(int? id)
        {
            if (id != null)
            {
                var followedList = _topicRepository.MemberFollowedTopics((int)id);

                return View(followedList);
            }

            var list = _topicRepository.GetAll().Take(8).ToList();

            return View(list);
        }
    }
}
