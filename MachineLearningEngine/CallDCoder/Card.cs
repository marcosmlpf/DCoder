using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CallDCoder
{
    [Newtonsoft.Json.JsonObject(MemberSerialization = Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Card
    {

        [Newtonsoft.Json.JsonProperty]
        public int MyProperty { get; set; }

        [Newtonsoft.Json.JsonProperty]
        public  long? id{ get; set; }

        [Newtonsoft.Json.JsonProperty]
        public  DateTime createdAt;

        [Newtonsoft.Json.JsonProperty]
        public  String mnemonic{ get; set; }

        [Newtonsoft.Json.JsonProperty]
        public  bool featured{ get; set; }

        [Newtonsoft.Json.JsonProperty]
        public  bool autoModerated{ get; set; }

        [Newtonsoft.Json.JsonProperty]
        public  DateTime? updated{ get; set; }

        [Newtonsoft.Json.JsonProperty]
        public  long authorId{ get; set; }

        [Newtonsoft.Json.JsonProperty]
        public  String authorDisplayName{ get; set; }

        [Newtonsoft.Json.JsonProperty]
        public  String authorImageURL{ get; set; }

        [Newtonsoft.Json.JsonProperty]
        public  String authorEmail{ get; set; }

        [Newtonsoft.Json.JsonProperty]
        public  String providerUserId{ get; set; }

        [Newtonsoft.Json.JsonProperty]
        public  List<String> categoryNames{ get; set; }

        [Newtonsoft.Json.JsonProperty]
        public  DateTime? expirationDate{ get; set; }

        [Newtonsoft.Json.JsonProperty]
        public  DateTime? publishingDate{ get; set; }

        [Newtonsoft.Json.JsonProperty]
        public  int securityLevel{ get; set; }

        //content

        [Newtonsoft.Json.JsonProperty]
        public  String title{ get; set; }

        [Newtonsoft.Json.JsonProperty]
        public  String description{ get; set; }

        [Newtonsoft.Json.JsonProperty]
        public  String content{ get; set; }

        [Newtonsoft.Json.JsonProperty]
        public  String providerContentId{ get; set; }

        [Newtonsoft.Json.JsonProperty]
        public  String providerContentURL{ get; set; }

        [Newtonsoft.Json.JsonProperty]
        public  String providerId{ get; set; }

        [Newtonsoft.Json.JsonProperty]
        public  DateTime providerUpdated{ get; set; }

        [Newtonsoft.Json.JsonProperty]
        public  DateTime providerPublished{ get; set; }

        //i18n

        [Newtonsoft.Json.JsonProperty]
        public  List<String> languages{ get; set; }

        [Newtonsoft.Json.JsonProperty]
        public  String detectedLanguage{ get; set; }

        [Newtonsoft.Json.JsonProperty]
        public  List<String> regions{ get; set; }

        [Newtonsoft.Json.JsonProperty]
        public  String geoCode{ get; set; }

        [Newtonsoft.Json.JsonProperty]
        public  String address{ get; set; }

        [Newtonsoft.Json.JsonProperty]
        public  String placeName{ get; set; }

        [Newtonsoft.Json.JsonProperty]
        public  String community{ get; set; }

        [Newtonsoft.Json.JsonProperty]
        public  String communityDisplayName{ get; set; }

        [Newtonsoft.Json.JsonProperty]
        public  List<Attachment> attachments{ get; set; }

        [Newtonsoft.Json.JsonProperty]
        public List<string> hashtagList { get; set; }

        public Card()
        {
            categoryNames = new List<String>();
            languages = new List<String>();
            regions = new List<String>();
            attachments = new List<Attachment>();
            hashtagList = new List<string>();
        }

        //public long getId()
        //{
        //    return id;
        //}
        //public void setId(long id)
        //{
        //    this.id = id;
        //}
        //public DateTime getCreatedAt()
        //{
        //    return createdAt;
        //}
        //public void setCreatedAt(DateTime createdAt)
        //{
        //    this.createdAt = createdAt;
        //}
        //public String getMnemonic()
        //{
        //    return mnemonic;
        //}
        //public void setMnemonic(String mnemonic)
        //{
        //    this.mnemonic = mnemonic;
        //}
        //public bool getIsFeatured()
        //{
        //    return isFeatured;
        //}
        //public void setIsFeatured(bool isFeatured)
        //{
        //    this.isFeatured = isFeatured;
        //}
        ////public bool isAutoModerated()
        ////{
        ////    return isAutoModerated;
        ////}
        ////public void setAutoModerated(bool isAutoModerated)
        ////{
        ////    this.isAutoModerated = isAutoModerated;
        ////}
        //public DateTime? getUpdated()
        //{
        //    return updated;
        //}
        //public void setUpdated(DateTime? updated)
        //{
        //    this.updated = updated;
        //}
        //public long getAuthorId()
        //{
        //    return authorId;
        //}
        //public void setAuthorId(long authorId)
        //{
        //    this.authorId = authorId;
        //}
        //public String getAuthorDisplayName()
        //{
        //    return authorDisplayName;
        //}
        //public void setAuthorDisplayName(String authorDisplayName)
        //{
        //    this.authorDisplayName = authorDisplayName;
        //}
        //public String getAuthorImageURL()
        //{
        //    return authorImageURL;
        //}
        //public void setAuthorImageURL(String authorImageURL)
        //{
        //    this.authorImageURL = authorImageURL;
        //}
        //public String getAuthorEmail()
        //{
        //    return authorEmail;
        //}
        //public void setAuthorEmail(String authorEmail)
        //{
        //    this.authorEmail = authorEmail;
        //}
        //public String getProviderUserId()
        //{
        //    return providerUserId;
        //}
        //public void setProviderUserId(String providerUserId)
        //{
        //    this.providerUserId = providerUserId;
        //}
        //public List<String> getCategoryNames()
        //{
        //    return categoryNames;
        //}
        //public void setCategoryNames(List<String> categoryNames)
        //{
        //    this.categoryNames = categoryNames;
        //}
        public void addCategory(String category)
        {
            this.categoryNames.Add(category);
        }

        //public DateTime? getExpirationDate()
        //{
        //    return expirationDate;
        //}

        //public void setExpirationDate(DateTime? expirationDate)
        //{
        //    this.expirationDate = expirationDate;
        //}

        //public DateTime? getPublishingDate()
        //{
        //    return publishingDate;
        //}

        //public void setPublishingDate(DateTime? publishingDate)
        //{
        //    this.publishingDate = publishingDate;
        //}

        //public String getTitle()
        //{
        //    return title;
        //}

        //public void setTitle(String title)
        //{
        //    this.title = title;
        //}

        //public String getDescription()
        //{
        //    return description;
        //}

        //public void setDescription(String description)
        //{
        //    this.description = description;
        //}

        //public String getContent()
        //{
        //    return content;
        //}

        //public void setContent(String content)
        //{
        //    this.content = content;
        //}

        //public String getProviderContentId()
        //{
        //    return providerContentId;
        //}

        //public void setProviderContentId(String providerContentId)
        //{
        //    this.providerContentId = providerContentId;
        //}

        //public String getProviderContentURL()
        //{
        //    return providerContentURL;
        //}

        //public void setProviderContentURL(String providerContentURL)
        //{
        //    this.providerContentURL = providerContentURL;
        //}

        //public String getProviderId()
        //{
        //    return providerId;
        //}

        //public void setProviderId(String providerId)
        //{
        //    this.providerId = providerId;
        //}

        //public DateTime getProviderUpdated()
        //{
        //    return providerUpdated;
        //}

        //public void setProviderUpdated(DateTime providerUpdated)
        //{
        //    this.providerUpdated = providerUpdated;
        //}

        //public DateTime getProviderPublished()
        //{
        //    return providerPublished;
        //}

        //public void setProviderPublished(DateTime providerPublished)
        //{
        //    this.providerPublished = providerPublished;
        //}

        //public List<String> getLanguages()
        //{
        //    return languages;
        //}

        //public void setLanguages(List<String> languages)
        //{
        //    this.languages = languages;
        //}

        //public String getDetectedLanguage()
        //{
        //    return detectedLanguage;
        //}

        //public void setDetectedLanguage(String detectedLanguage)
        //{
        //    this.detectedLanguage = detectedLanguage;
        //}

        //public List<String> getRegions()
        //{
        //    return regions;
        //}

        //public void setRegions(List<String> regions)
        //{
        //    this.regions = regions;
        //}

        //public String getGeoCode()
        //{
        //    return geoCode;
        //}

        //public void setGeoCode(String geoCode)
        //{
        //    this.geoCode = geoCode;
        //}

        //public String getAddress()
        //{
        //    return address;
        //}

        //public void setAddress(String address)
        //{
        //    this.address = address;
        //}

        //public String getPlaceName()
        //{
        //    return placeName;
        //}

        //public void setPlaceName(String placeName)
        //{
        //    this.placeName = placeName;
        //}

        //public String getCommunity()
        //{
        //    return community;
        //}

        //public void setCommunity(String community)
        //{
        //    this.community = community;
        //}

        //public String getCommunityDisplayName()
        //{
        //    return communityDisplayName;
        //}

        //public void setCommunityDisplayName(String communityDisplayName)
        //{
        //    this.communityDisplayName = communityDisplayName;
        //}

        public void addLanguage(String language)
        {
            languages.Add(language);
        }

        public void addRegion(String region)
        {
            regions.Add(region);
        }

        //public int getSecurityLevel()
        //{
        //    return securityLevel;
        //}

        //public void setSecurityLevel(int securityLevel)
        //{
        //    this.securityLevel = securityLevel;
        //}

        //public List<Attachment> getAttachments()
        //{
        //    return attachments;
        //}

        //public void setAttachments(List<Attachment> attachments)
        //{
        //    this.attachments = attachments;
        //}

        //public void addAttachment(Attachment attachment)
        //{
        //    this.attachments.Add(attachment);
        //}

    }

    public class Attachment
    {

        public  long id{ get; set; }
        public  long cardId{ get; set; }
        public  String type{ get; set; }
        public  String gcsBucket{ get; set; }
        public  String gcsFileName{ get; set; }
        public  String displayName{ get; set; }
        public  String content{ get; set; }
        public  String contentURL{ get; set; }
        public  String imageURL{ get; set; }
        public  String imageType{ get; set; }
        public  long imageHeight{ get; set; }
        public  long imageWidth{ get; set; }
        public  String originalImageURL{ get; set; }
        public  String fullImageURL{ get; set; }
        public  long fullImageHeight{ get; set; }
        public  long fullImageWidth{ get; set; }
        public  String embedType{ get; set; }
        public  String embedURL{ get; set; }
        public  String documentType{ get; set; }
        public  String tableauUrl{ get; set; }
        public  String tableauSource{ get; set; }
        public  String worksheetName{ get; set; }
        public long getId()
        {
            return id;
        }
        //public void setId(long id)
        //{
        //    this.id = id;
        //}
        //public long getCardId()
        //{
        //    return cardId;
        //}
        //public void setCardId(long cardId)
        //{
        //    this.cardId = cardId;
        //}
        //public String getType()
        //{
        //    return type;
        //}
        //public void setType(String type)
        //{
        //    this.type = type;
        //}
        //public String getGcsBucket()
        //{
        //    return gcsBucket;
        //}
        //public void setGcsBucket(String gcsBucket)
        //{
        //    this.gcsBucket = gcsBucket;
        //}
        //public String getGcsFileName()
        //{
        //    return gcsFileName;
        //}
        //public void setGcsFileName(String gcsFileName)
        //{
        //    this.gcsFileName = gcsFileName;
        //}
        //public String getDisplayName()
        //{
        //    return displayName;
        //}
        //public void setDisplayName(String displayName)
        //{
        //    this.displayName = displayName;
        //}
        //public String getContent()
        //{
        //    return content;
        //}
        //public void setContent(String content)
        //{
        //    this.content = content;
        //}
        //public String getContentURL()
        //{
        //    return contentURL;
        //}
        //public void setContentURL(String contentURL)
        //{
        //    this.contentURL = contentURL;
        //}
        //public String getImageURL()
        //{
        //    return imageURL;
        //}
        //public void setImageURL(String imageURL)
        //{
        //    this.imageURL = imageURL;
        //}
        //public String getImageType()
        //{
        //    return imageType;
        //}
        //public void setImageType(String imageType)
        //{
        //    this.imageType = imageType;
        //}
        //public long getImageHeight()
        //{
        //    return imageHeight;
        //}
        //public void setImageHeight(long imageHeight)
        //{
        //    this.imageHeight = imageHeight;
        //}
        //public long getImageWidth()
        //{
        //    return imageWidth;
        //}
        //public void setImageWidth(long imageWidth)
        //{
        //    this.imageWidth = imageWidth;
        //}
        //public String getOriginalImageURL()
        //{
        //    return originalImageURL;
        //}
        //public void setOriginalImageURL(String originalImageURL)
        //{
        //    this.originalImageURL = originalImageURL;
        //}
        //public String getFullImageURL()
        //{
        //    return fullImageURL;
        //}
        //public void setFullImageURL(String fullImageURL)
        //{
        //    this.fullImageURL = fullImageURL;
        //}
        //public long getFullImageHeight()
        //{
        //    return fullImageHeight;
        //}
        //public void setFullImageHeight(long fullImageHeight)
        //{
        //    this.fullImageHeight = fullImageHeight;
        //}
        //public long getFullImageWidth()
        //{
        //    return fullImageWidth;
        //}
        //public void setFullImageWidth(long fullImageWidth)
        //{
        //    this.fullImageWidth = fullImageWidth;
        //}
        //public String getEmbedType()
        //{
        //    return embedType;
        //}
        //public void setEmbedType(String embedType)
        //{
        //    this.embedType = embedType;
        //}
        //public String getEmbedURL()
        //{
        //    return embedURL;
        //}
        //public void setEmbedURL(String embedURL)
        //{
        //    this.embedURL = embedURL;
        //}
        //public String getDocumentType()
        //{
        //    return documentType;
        //}
        //public void setDocumentType(String documentType)
        //{
        //    this.documentType = documentType;
        //}
        //public String getTableauUrl()
        //{
        //    return tableauUrl;
        //}
        //public void setTableauUrl(String tableauUrl)
        //{
        //    this.tableauUrl = tableauUrl;
        //}
        //public String getTableauSource()
        //{
        //    return tableauSource;
        //}
        //public void setTableauSource(String tableauSource)
        //{
        //    this.tableauSource = tableauSource;
        //}
        //public String getWorksheetName()
        //{
        //    return worksheetName;
        //}
        //public void setWorksheetName(String worksheetName)
        //{
        //    this.worksheetName = worksheetName;
        //}

    }
}
