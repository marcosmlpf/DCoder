using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using SmartCanvasAPIWrapper.Model;

namespace SmartCanvasAPIWrapper
{
    public class CardModel
    {

        public static List<Card> getCardsFromJSON(String JSONString)
        {

            List<Card> cards = new List<Card>();

            try
            {

                JArray jsonArray = JArray.Parse(JSONString);

                foreach (var jsonNode in jsonArray.Children<JObject>())
                {
                    Card card = new Card();
                    List<BlocksInformations> blocks = new List<BlocksInformations>();

                    if (!IsNullOrEmpty(jsonNode["id"]))
                        card.id = jsonNode["id"].Value<long>();

                    if (!IsNullOrEmpty(jsonNode["authorId"]))
                        card.authorId = jsonNode["authorId"].Value<long>();

                    if (!IsNullOrEmpty(jsonNode["providerId"]))
                        card.providerId = jsonNode["providerId"].Value<string>();

                    if (!IsNullOrEmpty(jsonNode["mnemonic"]) )
                        card.mnemonic = jsonNode["mnemonic"].Value<string>();

                    if (!IsNullOrEmpty(jsonNode["createDate"]))
                        card.createdAt = jsonNode["createDate"].Value<DateTime>();

                    if (!IsNullOrEmpty(jsonNode["feature"]) )
                        card.featured = jsonNode["feature"].Value<bool>();

                    if (!IsNullOrEmpty(jsonNode["updateData"]) )
                        card.updated = jsonNode["updateData"].Value<DateTime?>();

                    //if (jsonNode["recommendationRequestId"]!=null)
                    //    card.rrecommendationRequestId = jsonArray.getJSONObject(x).getInt("recommendationRequestId");

                    cards.Add(card);
                }

                #region blocks
                //        if (jsonNode["blocks")!=null) {

                //            JSONArray blocksJsonArray = new JSONArray(jsonArray["blocks"));

                //            for (int i = 0; i < blocksJsonArray.length(); i++) {
                //                if (blocksJsonArray.getJSONObject(i).getString("type").equals("content")) {
                //                    CardContent content = new CardContent();

                //                    if (!blocksJsonArray.getJSONObject(i).isNull("title"))
                //                        content.Title = blocksJsonArray.getJSONObject(i).getString("title");

                //                    if (!blocksJsonArray.getJSONObject(i).isNull("summary"))
                //                        content.Summary = blocksJsonArray.getJSONObject(i).getString("summary");

                //                    if (!blocksJsonArray.getJSONObject(i).isNull("content"))
                //                        content.Content = blocksJsonArray.getJSONObject(i).getString("content");

                //                    if (!blocksJsonArray.getJSONObject(i).isNull("providerContentURL"))
                //                        content.ProviderContentUrl = blocksJsonArray.getJSONObject(i).getString("providerContentURL");

                //                    card.Content = content;
                //                }
                //                else if (blocksJsonArray.getJSONObject(i).getString("type").equals("author")) {
                //                    CardAuthor author = new CardAuthor();

                //                    if (!blocksJsonArray.getJSONObject(i).isNull("authorDisplayName"))
                //                        author.AuthorDisplayName = blocksJsonArray.getJSONObject(i).getString("authorDisplayName");

                //                    if (!blocksJsonArray.getJSONObject(i).isNull("authorAlias"))
                //                        author.AuthorAlias = blocksJsonArray.getJSONObject(i).getString("authorAlias");

                //                    if (!blocksJsonArray.getJSONObject(i).isNull("authorId"))
                //                        author.AuthorId = blocksJsonArray.getJSONObject(i).getInt("authorId");

                //                    if (!blocksJsonArray.getJSONObject(i).isNull("authorImageURL"))
                //                        author.AuthorImageUrl = blocksJsonArray.getJSONObject(i).getString("authorImageURL");

                //                    if (!blocksJsonArray.getJSONObject(i).isNull("providerUserId"))
                //                        author.ProviderUserId = blocksJsonArray.getJSONObject(i).getString("providerUserId");

                //                    if (!blocksJsonArray.getJSONObject(i).isNull("publishDate"))
                //                        author.PublishDate = blocksJsonArray.getJSONObject(i).getInt("publishDate");

                //                    card.Author = author;
                //                }
                //                else if (blocksJsonArray.getJSONObject(i).getString("type").equals("photo")) {
                //                    BlockTypePhoto photo = new BlockTypePhoto();

                //                    BlockType type = new BlockType();
                //                    type.Type = "photo";

                //                    photo.BlockType = type;

                //                    if (!blocksJsonArray.getJSONObject(i).isNull("imageURL"))
                //                        photo.ImageUrl = blocksJsonArray.getJSONObject(i).getString("imageURL");

                //                    if (!blocksJsonArray.getJSONObject(i).isNull("imageType"))
                //                        photo.ImageType = blocksJsonArray.getJSONObject(i).getString("imageType");

                //                    if (!blocksJsonArray.getJSONObject(i).isNull("imageHeight"))
                //                        photo.ImageHeight = blocksJsonArray.getJSONObject(i).getInt("imageHeight");

                //                    if (!blocksJsonArray.getJSONObject(i).isNull("imageWidth"))
                //                        photo.ImageWidth = blocksJsonArray.getJSONObject(i).getInt("imageWidth");

                //                    if (!blocksJsonArray.getJSONObject(i).isNull("imageOriginalURL"))
                //                        photo.OriginalImageUrl = blocksJsonArray.getJSONObject(i).getString("imageOriginalURL");

                //                    blocks.add(photo);

                //                    card.Type = CardType.CardTypes.Photo;

                //                }
                //                else if (blocksJsonArray.getJSONObject(i).getString("type").equals("youtube")) {
                //                    BlockTypeYoutube youtube = new BlockTypeYoutube();

                //                    BlockType type = new BlockType();
                //                    type.Type = "youtube";

                //                    youtube.BlockType = type;

                //                    if (!blocksJsonArray.getJSONObject(i).isNull("embedType"))
                //                        youtube.EmbedType = blocksJsonArray.getJSONObject(i).getString("embedType");

                //                    if (!blocksJsonArray.getJSONObject(i).isNull("embedURL"))
                //                        youtube.EmbedURL = blocksJsonArray.getJSONObject(i).getString("embedURL");

                //                    if (!blocksJsonArray.getJSONObject(i).isNull("url"))
                //                        youtube.URL = blocksJsonArray.getJSONObject(i).getString("url");

                //                    if (!blocksJsonArray.getJSONObject(i).isNull("imageType"))
                //                        youtube.ImageType = blocksJsonArray.getJSONObject(i).getString("imageType");

                //                    if (!blocksJsonArray.getJSONObject(i).isNull("imageHeight"))
                //                        youtube.ImageHeight = blocksJsonArray.getJSONObject(i).getInt("imageHeight");

                //                    if (!blocksJsonArray.getJSONObject(i).isNull("imageWidth"))
                //                        youtube.ImageWidth = blocksJsonArray.getJSONObject(i).getInt("imageWidth");

                //                    if (!blocksJsonArray.getJSONObject(i).isNull("imageUrl"))
                //                        youtube.ImageUrl = blocksJsonArray.getJSONObject(i).getString("imageUrl");

                //                    blocks.add(youtube);

                //                    card.Type = CardType.CardTypes.Youtube;

                //                }
                //                else if (blocksJsonArray.getJSONObject(i).getString("type").equals("article")) {
                //                    BlockTypeArticle article = new BlockTypeArticle();

                //                    BlockType type = new BlockType();
                //                    type.Type = "article";

                //                    article.BlockType = type;

                //                    if (!blocksJsonArray.getJSONObject(i).isNull("contentURL"))
                //                        article.ContentURL = blocksJsonArray.getJSONObject(i).getString("contentURL");

                //                    if (!blocksJsonArray.getJSONObject(i).isNull("imageURL"))
                //                        article.ImageUrl = blocksJsonArray.getJSONObject(i).getString("imageURL");

                //                    if (!blocksJsonArray.getJSONObject(i).isNull("displayName"))
                //                        article.DisplayName = blocksJsonArray.getJSONObject(i).getString("displayName");

                //                    if (!blocksJsonArray.getJSONObject(i).isNull("imageHeight"))
                //                        article.ImageHeight = blocksJsonArray.getJSONObject(i).getInt("imageHeight");

                //                    if (!blocksJsonArray.getJSONObject(i).isNull("imageWidth"))
                //                        article.ImageWidth = blocksJsonArray.getJSONObject(i).getInt("imageWidth");

                //                    blocks.add(article);

                //                    card.Type = CardType.CardTypes.Article;

                //                }
                //            }

                #endregion
                //card.Blocks = blocks;

            }
            catch (Exception e)
            {
                throw;
            }

            return cards;
        }

        public static bool IsNullOrEmpty(JToken token)
        {
            return (token == null) ||
                   (token.Type == JTokenType.Array && !token.HasValues) ||
                   (token.Type == JTokenType.Object && !token.HasValues) ||
                   (token.Type == JTokenType.String && token.ToString() == String.Empty) ||
                   (token.Type == JTokenType.Null);
        }
    }

    class BlocksInformations
    {

    }

}