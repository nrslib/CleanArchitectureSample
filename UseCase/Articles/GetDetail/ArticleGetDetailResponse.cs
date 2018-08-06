using MyLibrary.Options;
using UseCase.Articles.Common;
using UseCase.Core;

namespace UseCase.Articles.GetDetail
{
    public class ArticleGetDetailResponse : IResponse
    {
        public ArticleGetDetailResponse(Option<ArticleDto> article) {
            Article = article;
        }

        public Option<ArticleDto> Article { get; }
    }
}
