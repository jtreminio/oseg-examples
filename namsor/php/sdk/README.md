# namsor/client

NamSor API v2 : enpoints to process personal names (gender, cultural origin or ethnicity) in all alphabets or languages. By default, enpoints use 1 unit per name (ex. Gender), but Ethnicity classification uses 10 to 20 units per name depending on taxonomy. Use GET methods for small tests, but prefer POST methods for higher throughput (batch processing of up to 100 names at a time). Need something you can't find here? We have many more features coming soon. Let us know, we'll do our best to add it! 

For more information, please visit [http://www.namsor.com/](http://www.namsor.com/).

## Installation & Usage

### Requirements

PHP 7.4 and later.
Should also work with PHP 8.0.

### Composer

To install the bindings via [Composer](https://getcomposer.org/), add the following to `composer.json`:

```json
{
  "repositories": [
    {
      "type": "vcs",
      "url": "https://github.com/GIT_USER_ID/GIT_REPO_ID.git"
    }
  ],
  "require": {
    "GIT_USER_ID/GIT_REPO_ID": "*@dev"
  }
}
```

Then run `composer install`

### Manual Installation

Download the files and include `autoload.php`:

```php
<?php
require_once('/path/to/namsor/client/vendor/autoload.php');
```

## Getting Started

Please follow the [installation procedure](#installation--usage) and then run the following:

```php
<?php
require_once(__DIR__ . '/vendor/autoload.php');



// Configure API key authorization: api_key
$config = Namsor\Client\Configuration::getDefaultConfiguration()->setApiKey('X-API-KEY', 'YOUR_API_KEY');
// Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
// $config = Namsor\Client\Configuration::getDefaultConfiguration()->setApiKeyPrefix('X-API-KEY', 'Bearer');


$apiInstance = new Namsor\Client\Api\AdminApi(
    // If you want use custom http client, pass your client which implements `GuzzleHttp\ClientInterface`.
    // This is optional, `GuzzleHttp\Client` will be used as default.
    new GuzzleHttp\Client(),
    $config
);
$source = 'source_example'; // string
$anonymized = True; // bool

try {
    $apiInstance->anonymize($source, $anonymized);
} catch (Exception $e) {
    echo 'Exception when calling AdminApi->anonymize: ', $e->getMessage(), PHP_EOL;
}

```

## API Endpoints

All URIs are relative to *https://v2.namsor.com/NamSorAPIv2*

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*AdminApi* | [**anonymize**](docs/Api/AdminApi.md#anonymize) | **GET** /api2/json/anonymize/{source}/{anonymized} | Activate/deactivate anonymization for a source.
*AdminApi* | [**anonymize1**](docs/Api/AdminApi.md#anonymize1) | **GET** /api2/json/anonymize/{source}/{anonymized}/{token} | Activate/deactivate anonymization for a source.
*AdminApi* | [**apiKeyInfo**](docs/Api/AdminApi.md#apikeyinfo) | **GET** /api2/json/apiKeyInfo | Read API Key info.
*AdminApi* | [**apiStatus**](docs/Api/AdminApi.md#apistatus) | **GET** /api2/json/apiStatus | Prints the current status of the classifiers. A classifier name in apiStatus corresponds to a service name in apiServices.
*AdminApi* | [**apiUsage**](docs/Api/AdminApi.md#apiusage) | **GET** /api2/json/apiUsage | Print current API usage.
*AdminApi* | [**apiUsageHistory**](docs/Api/AdminApi.md#apiusagehistory) | **GET** /api2/json/apiUsageHistory | Print historical API usage.
*AdminApi* | [**apiUsageHistoryAggregate**](docs/Api/AdminApi.md#apiusagehistoryaggregate) | **GET** /api2/json/apiUsageHistoryAggregate | Print historical API usage (in an aggregated view, by service, by day/hour/min).
*AdminApi* | [**availableServices**](docs/Api/AdminApi.md#availableservices) | **GET** /api2/json/apiServices | List of classification services and usage cost in Units per classification (default is 1&#x3D;ONE Unit). Some API endpoints (ex. Corridor) combine multiple classifiers.
*AdminApi* | [**disable**](docs/Api/AdminApi.md#disable) | **GET** /api2/json/disable/{source}/{disabled} | Activate/deactivate an API Key.
*AdminApi* | [**learnable**](docs/Api/AdminApi.md#learnable) | **GET** /api2/json/learnable/{source}/{learnable}/{token} | Activate/deactivate learning from a source.
*AdminApi* | [**learnable1**](docs/Api/AdminApi.md#learnable1) | **GET** /api2/json/learnable/{source}/{learnable} | Activate/deactivate learning from a source.
*AdminApi* | [**regions**](docs/Api/AdminApi.md#regions) | **GET** /api2/json/regions | Print basic source statistics.
*AdminApi* | [**softwareVersion**](docs/Api/AdminApi.md#softwareversion) | **GET** /api2/json/softwareVersion | Get the current software version
*AdminApi* | [**taxonomyClasses**](docs/Api/AdminApi.md#taxonomyclasses) | **GET** /api2/json/taxonomyClasses/{classifierName} | Print the taxonomy classes valid for the given classifier.
*ChineseApi* | [**chineseNameCandidates**](docs/Api/ChineseApi.md#chinesenamecandidates) | **GET** /api2/json/chineseNameCandidates/{chineseSurnameLatin}/{chineseGivenNameLatin} | Identify Chinese name candidates, based on the romanized name ex. Wang Xiaoming
*ChineseApi* | [**chineseNameCandidatesBatch**](docs/Api/ChineseApi.md#chinesenamecandidatesbatch) | **POST** /api2/json/chineseNameCandidatesBatch | Identify Chinese name candidates, based on the romanized name (firstName &#x3D; chineseGivenName; lastName&#x3D;chineseSurname), ex. Wang Xiaoming
*ChineseApi* | [**chineseNameCandidatesGenderBatch**](docs/Api/ChineseApi.md#chinesenamecandidatesgenderbatch) | **POST** /api2/json/chineseNameCandidatesGenderBatch | Identify Chinese name candidates, based on the romanized name (firstName &#x3D; chineseGivenName; lastName&#x3D;chineseSurname) ex. Wang Xiaoming.
*ChineseApi* | [**chineseNameGenderCandidates**](docs/Api/ChineseApi.md#chinesenamegendercandidates) | **GET** /api2/json/chineseNameGenderCandidates/{chineseSurnameLatin}/{chineseGivenNameLatin}/{knownGender} | Identify Chinese name candidates, based on the romanized name ex. Wang Xiaoming - having a known gender (&#39;male&#39; or &#39;female&#39;)
*ChineseApi* | [**chineseNameMatch**](docs/Api/ChineseApi.md#chinesenamematch) | **GET** /api2/json/chineseNameMatch/{chineseSurnameLatin}/{chineseGivenNameLatin}/{chineseName} | Return a score for matching Chinese name ex. 王晓明 with a romanized name ex. Wang Xiaoming
*ChineseApi* | [**chineseNameMatchBatch**](docs/Api/ChineseApi.md#chinesenamematchbatch) | **POST** /api2/json/chineseNameMatchBatch | Identify Chinese name candidates, based on the romanized name (firstName &#x3D; chineseGivenName; lastName&#x3D;chineseSurname), ex. Wang Xiaoming
*ChineseApi* | [**genderChineseName**](docs/Api/ChineseApi.md#genderchinesename) | **GET** /api2/json/genderChineseName/{chineseName} | Infer the likely gender of a Chinese full name ex. 王晓明
*ChineseApi* | [**genderChineseNameBatch**](docs/Api/ChineseApi.md#genderchinesenamebatch) | **POST** /api2/json/genderChineseNameBatch | Infer the likely gender of up to 100 full names ex. 王晓明
*ChineseApi* | [**genderChineseNamePinyin**](docs/Api/ChineseApi.md#genderchinesenamepinyin) | **GET** /api2/json/genderChineseNamePinyin/{chineseSurnameLatin}/{chineseGivenNameLatin} | Infer the likely gender of a Chinese name in LATIN (Pinyin).
*ChineseApi* | [**genderChineseNamePinyinBatch**](docs/Api/ChineseApi.md#genderchinesenamepinyinbatch) | **POST** /api2/json/genderChineseNamePinyinBatch | Infer the likely gender of up to 100 Chinese names in LATIN (Pinyin).
*ChineseApi* | [**parseChineseName**](docs/Api/ChineseApi.md#parsechinesename) | **GET** /api2/json/parseChineseName/{chineseName} | Infer the likely first/last name structure of a name, ex. 王晓明 -&gt; 王(surname) 晓明(given name)
*ChineseApi* | [**parseChineseNameBatch**](docs/Api/ChineseApi.md#parsechinesenamebatch) | **POST** /api2/json/parseChineseNameBatch | Infer the likely first/last name structure of a name, ex. 王晓明 -&gt; 王(surname) 晓明(given name).
*ChineseApi* | [**pinyinChineseName**](docs/Api/ChineseApi.md#pinyinchinesename) | **GET** /api2/json/pinyinChineseName/{chineseName} | Romanize the Chinese name to Pinyin, ex. 王晓明 -&gt; Wang (surname) Xiaoming (given name)
*ChineseApi* | [**pinyinChineseNameBatch**](docs/Api/ChineseApi.md#pinyinchinesenamebatch) | **POST** /api2/json/pinyinChineseNameBatch | Romanize a list of Chinese name to Pinyin, ex. 王晓明 -&gt; Wang (surname) Xiaoming (given name).
*GeneralApi* | [**nameType**](docs/Api/GeneralApi.md#nametype) | **GET** /api2/json/nameType/{properNoun} | Infer the likely type of a proper noun (personal name, brand name, place name etc.)
*GeneralApi* | [**nameTypeBatch**](docs/Api/GeneralApi.md#nametypebatch) | **POST** /api2/json/nameTypeBatch | Infer the likely common type of up to 100 proper nouns (personal name, brand name, place name etc.)
*GeneralApi* | [**nameTypeGeo**](docs/Api/GeneralApi.md#nametypegeo) | **GET** /api2/json/nameTypeGeo/{properNoun}/{countryIso2} | Infer the likely type of a proper noun (personal name, brand name, place name etc.)
*GeneralApi* | [**nameTypeGeoBatch**](docs/Api/GeneralApi.md#nametypegeobatch) | **POST** /api2/json/nameTypeGeoBatch | Infer the likely common type of up to 100 proper nouns (personal name, brand name, place name etc.)
*IndianApi* | [**casteIndianBatch**](docs/Api/IndianApi.md#casteindianbatch) | **POST** /api2/json/casteIndianBatch | [USES 10 UNITS PER NAME] Infer the likely Indian name caste of up to 100 personal Indian Hindu names.
*IndianApi* | [**castegroupIndian**](docs/Api/IndianApi.md#castegroupindian) | **GET** /api2/json/castegroupIndian/{subDivisionIso31662}/{firstName}/{lastName} | [USES 10 UNITS PER NAME] Infer the likely Indian name castegroup of a first / last name.
*IndianApi* | [**castegroupIndianBatch**](docs/Api/IndianApi.md#castegroupindianbatch) | **POST** /api2/json/castegroupIndianBatch | [USES 10 UNITS PER NAME] Infer the likely Indian name castegroup of up to 100 personal first / last names.
*IndianApi* | [**castegroupIndianFull**](docs/Api/IndianApi.md#castegroupindianfull) | **GET** /api2/json/castegroupIndianFull/{subDivisionIso31662}/{personalNameFull} | [USES 10 UNITS PER NAME] Infer the likely Indian name castegroup of a personal full name.
*IndianApi* | [**castegroupIndianFullBatch**](docs/Api/IndianApi.md#castegroupindianfullbatch) | **POST** /api2/json/castegroupIndianFullBatch | [USES 10 UNITS PER NAME] Infer the likely Indian name castegroup of up to 100 personal full names.
*IndianApi* | [**castegroupIndianHindu**](docs/Api/IndianApi.md#castegroupindianhindu) | **GET** /api2/json/casteIndian/{subDivisionIso31662}/{firstName}/{lastName} | [USES 10 UNITS PER NAME] Infer the likely Indian name caste of a personal Hindu name.
*IndianApi* | [**religion**](docs/Api/IndianApi.md#religion) | **GET** /api2/json/religionIndianFull/{subDivisionIso31662}/{personalNameFull} | [USES 10 UNITS PER NAME] Infer the likely religion of a personal Indian full name, provided the Indian state or Union territory (NB/ this can be inferred using the subclassification endpoint).
*IndianApi* | [**religion1**](docs/Api/IndianApi.md#religion1) | **GET** /api2/json/religionIndian/{subDivisionIso31662}/{firstName}/{lastName} | [USES 10 UNITS PER NAME] Infer the likely religion of a personal Indian first/last name, provided the Indian state or Union territory (NB/ this can be inferred using the subclassification endpoint).
*IndianApi* | [**religionIndianBatch**](docs/Api/IndianApi.md#religionindianbatch) | **POST** /api2/json/religionIndianBatch | [USES 10 UNITS PER NAME] Infer the likely religion of up to 100 personal first/last Indian names, provided the subclassification at State or Union territory level (NB/ can be inferred using the subclassification endpoint).
*IndianApi* | [**religionIndianFullBatch**](docs/Api/IndianApi.md#religionindianfullbatch) | **POST** /api2/json/religionIndianFullBatch | [USES 10 UNITS PER NAME] Infer the likely religion of up to 100 personal full Indian names, provided the subclassification at State or Union territory level (NB/ can be inferred using the subclassification endpoint).
*IndianApi* | [**subclassificationIndian**](docs/Api/IndianApi.md#subclassificationindian) | **GET** /api2/json/subclassificationIndian/{firstName}/{lastName} | [USES 10 UNITS PER NAME] Infer the likely Indian state of Union territory according to ISO 3166-2:IN based on the name.
*IndianApi* | [**subclassificationIndianBatch**](docs/Api/IndianApi.md#subclassificationindianbatch) | **POST** /api2/json/subclassificationIndianBatch | [USES 10 UNITS PER NAME] Infer the likely Indian state of Union territory according to ISO 3166-2:IN based on a list of up to 100 names.
*IndianApi* | [**subclassificationIndianFull**](docs/Api/IndianApi.md#subclassificationindianfull) | **GET** /api2/json/subclassificationIndianFull/{fullName} | [USES 10 UNITS PER NAME] Infer the likely Indian state of Union territory according to ISO 3166-2:IN based on the name.
*IndianApi* | [**subclassificationIndianFullBatch**](docs/Api/IndianApi.md#subclassificationindianfullbatch) | **POST** /api2/json/subclassificationIndianFullBatch | [USES 10 UNITS PER NAME] Infer the likely Indian state of Union territory according to ISO 3166-2:IN based on a list of up to 100 names.
*JapaneseApi* | [**genderJapaneseNameFull**](docs/Api/JapaneseApi.md#genderjapanesenamefull) | **GET** /api2/json/genderJapaneseNameFull/{japaneseName} | Infer the likely gender of a Japanese full name ex. 王晓明
*JapaneseApi* | [**genderJapaneseNameFullBatch**](docs/Api/JapaneseApi.md#genderjapanesenamefullbatch) | **POST** /api2/json/genderJapaneseNameFullBatch | Infer the likely gender of up to 100 full names
*JapaneseApi* | [**genderJapaneseNamePinyin**](docs/Api/JapaneseApi.md#genderjapanesenamepinyin) | **GET** /api2/json/genderJapaneseName/{japaneseSurname}/{japaneseGivenName} | Infer the likely gender of a Japanese name in LATIN (Pinyin).
*JapaneseApi* | [**genderJapaneseNamePinyinBatch**](docs/Api/JapaneseApi.md#genderjapanesenamepinyinbatch) | **POST** /api2/json/genderJapaneseNameBatch | Infer the likely gender of up to 100 Japanese names in LATIN (Pinyin).
*JapaneseApi* | [**japaneseNameGenderKanjiCandidatesBatch**](docs/Api/JapaneseApi.md#japanesenamegenderkanjicandidatesbatch) | **POST** /api2/json/japaneseNameGenderKanjiCandidatesBatch | Identify japanese name candidates in KANJI, based on the romanized name (firstName &#x3D; japaneseGivenName; lastName&#x3D;japaneseSurname) with KNOWN gender, ex. Yamamoto Sanae
*JapaneseApi* | [**japaneseNameKanjiCandidates**](docs/Api/JapaneseApi.md#japanesenamekanjicandidates) | **GET** /api2/json/japaneseNameKanjiCandidates/{japaneseSurnameLatin}/{japaneseGivenNameLatin}/{knownGender} | Identify japanese name candidates in KANJI, based on the romanized name ex. Yamamoto Sanae - and a known gender.
*JapaneseApi* | [**japaneseNameKanjiCandidates1**](docs/Api/JapaneseApi.md#japanesenamekanjicandidates1) | **GET** /api2/json/japaneseNameKanjiCandidates/{japaneseSurnameLatin}/{japaneseGivenNameLatin} | Identify japanese name candidates in KANJI, based on the romanized name ex. Yamamoto Sanae
*JapaneseApi* | [**japaneseNameKanjiCandidatesBatch**](docs/Api/JapaneseApi.md#japanesenamekanjicandidatesbatch) | **POST** /api2/json/japaneseNameKanjiCandidatesBatch | Identify japanese name candidates in KANJI, based on the romanized name (firstName &#x3D; japaneseGivenName; lastName&#x3D;japaneseSurname), ex. Yamamoto Sanae
*JapaneseApi* | [**japaneseNameLatinCandidates**](docs/Api/JapaneseApi.md#japanesenamelatincandidates) | **GET** /api2/json/japaneseNameLatinCandidates/{japaneseSurnameKanji}/{japaneseGivenNameKanji} | Romanize japanese name, based on the name in Kanji.
*JapaneseApi* | [**japaneseNameLatinCandidatesBatch**](docs/Api/JapaneseApi.md#japanesenamelatincandidatesbatch) | **POST** /api2/json/japaneseNameLatinCandidatesBatch | Romanize japanese names, based on the name in KANJI
*JapaneseApi* | [**japaneseNameMatch**](docs/Api/JapaneseApi.md#japanesenamematch) | **GET** /api2/json/japaneseNameMatch/{japaneseSurnameLatin}/{japaneseGivenNameLatin}/{japaneseName} | Return a score for matching Japanese name in KANJI ex. 山本 早苗 with a romanized name ex. Yamamoto Sanae
*JapaneseApi* | [**japaneseNameMatchBatch**](docs/Api/JapaneseApi.md#japanesenamematchbatch) | **POST** /api2/json/japaneseNameMatchBatch | Return a score for matching a list of Japanese names in KANJI ex. 山本 早苗 with romanized names ex. Yamamoto Sanae
*JapaneseApi* | [**japaneseNameMatchFeedbackLoop**](docs/Api/JapaneseApi.md#japanesenamematchfeedbackloop) | **GET** /api2/json/japaneseNameMatchFeedbackLoop/{japaneseSurnameLatin}/{japaneseGivenNameLatin}/{japaneseName} | [CREDITS 1 UNIT] Feedback loop to better perform matching Japanese name in KANJI ex. 山本 早苗 with a romanized name ex. Yamamoto Sanae
*JapaneseApi* | [**parseJapaneseName**](docs/Api/JapaneseApi.md#parsejapanesename) | **GET** /api2/json/parseJapaneseName/{japaneseName} | Infer the likely first/last name structure of a name, ex. 山本 早苗 or Yamamoto Sanae
*JapaneseApi* | [**parseJapaneseNameBatch**](docs/Api/JapaneseApi.md#parsejapanesenamebatch) | **POST** /api2/json/parseJapaneseNameBatch | Infer the likely first/last name structure of a name, ex. 山本 早苗 or Yamamoto Sanae
*PersonalApi* | [**communityEngage**](docs/Api/PersonalApi.md#communityengage) | **GET** /api2/json/communityEngage/{countryIso2}/{firstName}/{lastName} | [USES 20 UNITS PER NAME] Infer the likely ethnicity/diaspora, country, gender of a personal name, given a country of residence ISO2 code (ex. US, CA, AU, NZ etc.) for community engagement (require special module/pricing)
*PersonalApi* | [**communityEngageBatch**](docs/Api/PersonalApi.md#communityengagebatch) | **POST** /api2/json/communityEngageBatch | Infer the likely ethnicity/diaspora, country, gender of up to 100 personal names, given a country of residence ISO2 code (ex. US, CA, AU, NZ etc.) for community engagement (require special module/pricing)
*PersonalApi* | [**communityEngageFull**](docs/Api/PersonalApi.md#communityengagefull) | **GET** /api2/json/communityEngageFull/{countryIso2}/{personalNameFull} | [USES 20 UNITS PER NAME] Infer the likely ethnicity/diaspora, country, gender of a personal name, given a country of residence ISO2 code (ex. US, CA, AU, NZ etc.) for community engagement (require special module/pricing)
*PersonalApi* | [**communityEngageFullBatch**](docs/Api/PersonalApi.md#communityengagefullbatch) | **POST** /api2/json/communityEngageFullBatch | Infer the likely ethnicity/diaspora, country, gender of up to 100 personal names, given a country of residence ISO2 code (ex. US, CA, AU, NZ etc.) for community engagement (require special module/pricing)
*PersonalApi* | [**corridor**](docs/Api/PersonalApi.md#corridor) | **GET** /api2/json/corridor/{countryIso2From}/{firstNameFrom}/{lastNameFrom}/{countryIso2To}/{firstNameTo}/{lastNameTo} | [USES 20 UNITS PER NAME COUPLE] Infer several classifications for a cross border interaction between names (ex. remit, travel, intl com)
*PersonalApi* | [**corridorBatch**](docs/Api/PersonalApi.md#corridorbatch) | **POST** /api2/json/corridorBatch | [USES 20 UNITS PER NAME PAIR] Infer several classifications for up to 100 cross border interaction between names (ex. remit, travel, intl com)
*PersonalApi* | [**country**](docs/Api/PersonalApi.md#country) | **GET** /api2/json/country/{personalNameFull} | [USES 10 UNITS PER NAME] Infer the likely country of residence of a personal full name, or one surname. Assumes names as they are in the country of residence OR the country of origin.
*PersonalApi* | [**countryBatch**](docs/Api/PersonalApi.md#countrybatch) | **POST** /api2/json/countryBatch | [USES 10 UNITS PER NAME] Infer the likely country of residence of up to 100 personal full names, or surnames. Assumes names as they are in the country of residence OR the country of origin.
*PersonalApi* | [**countryFnLn**](docs/Api/PersonalApi.md#countryfnln) | **GET** /api2/json/countryFnLn/{firstName}/{lastName} | [USES 10 UNITS PER NAME] Infer the likely country of residence of a personal first / last name, or one surname. Assumes names as they are in the country of residence OR the country of origin.
*PersonalApi* | [**countryFnLnBatch**](docs/Api/PersonalApi.md#countryfnlnbatch) | **POST** /api2/json/countryFnLnBatch | [USES 10 UNITS PER NAME] Infer the likely country of residence of up to 100 personal first / last names, or surnames. Assumes names as they are in the country of residence OR the country of origin.
*PersonalApi* | [**diaspora**](docs/Api/PersonalApi.md#diaspora) | **GET** /api2/json/diaspora/{countryIso2}/{firstName}/{lastName} | [USES 20 UNITS PER NAME] Infer the likely ethnicity/diaspora of a personal name, given a country of residence ISO2 code (ex. US, CA, AU, NZ etc.)
*PersonalApi* | [**diasporaBatch**](docs/Api/PersonalApi.md#diasporabatch) | **POST** /api2/json/diasporaBatch | [USES 20 UNITS PER NAME] Infer the likely ethnicity/diaspora of up to 100 personal names, given a country of residence ISO2 code (ex. US, CA, AU, NZ etc.)
*PersonalApi* | [**diasporaFull**](docs/Api/PersonalApi.md#diasporafull) | **GET** /api2/json/diasporaFull/{countryIso2}/{personalNameFull} | [USES 20 UNITS PER NAME] Infer the likely ethnicity/diaspora of a personal name, given a country of residence ISO2 code (ex. US, CA, AU, NZ etc.)
*PersonalApi* | [**diasporaFullBatch**](docs/Api/PersonalApi.md#diasporafullbatch) | **POST** /api2/json/diasporaFullBatch | [USES 20 UNITS PER NAME] Infer the likely ethnicity/diaspora of up to 100 personal names, given a country of residence ISO2 code (ex. US, CA, AU, NZ etc.)
*PersonalApi* | [**gender**](docs/Api/PersonalApi.md#gender) | **GET** /api2/json/gender/{firstName} | Infer the likely gender of a just a fiven name, assuming default &#39;US&#39; local context. Please use preferably full names and local geographic context for better accuracy.
*PersonalApi* | [**gender1**](docs/Api/PersonalApi.md#gender1) | **GET** /api2/json/gender/{firstName}/{lastName} | Infer the likely gender of a name.
*PersonalApi* | [**genderBatch**](docs/Api/PersonalApi.md#genderbatch) | **POST** /api2/json/genderBatch | Infer the likely gender of up to 100 names, detecting automatically the cultural context.
*PersonalApi* | [**genderFull**](docs/Api/PersonalApi.md#genderfull) | **GET** /api2/json/genderFull/{fullName} | Infer the likely gender of a full name, ex. John H. Smith
*PersonalApi* | [**genderFullBatch**](docs/Api/PersonalApi.md#genderfullbatch) | **POST** /api2/json/genderFullBatch | Infer the likely gender of up to 100 full names, detecting automatically the cultural context.
*PersonalApi* | [**genderFullGeo**](docs/Api/PersonalApi.md#genderfullgeo) | **GET** /api2/json/genderFullGeo/{fullName}/{countryIso2} | Infer the likely gender of a full name, given a local context (ISO2 country code).
*PersonalApi* | [**genderFullGeoBatch**](docs/Api/PersonalApi.md#genderfullgeobatch) | **POST** /api2/json/genderFullGeoBatch | Infer the likely gender of up to 100 full names, with a given cultural context (country ISO2 code).
*PersonalApi* | [**genderGeo**](docs/Api/PersonalApi.md#gendergeo) | **GET** /api2/json/genderGeo/{firstName}/{lastName}/{countryIso2} | Infer the likely gender of a name, given a local context (ISO2 country code).
*PersonalApi* | [**genderGeoBatch**](docs/Api/PersonalApi.md#gendergeobatch) | **POST** /api2/json/genderGeoBatch | Infer the likely gender of up to 100 names, each given a local context (ISO2 country code).
*PersonalApi* | [**origin**](docs/Api/PersonalApi.md#origin) | **GET** /api2/json/origin/{firstName}/{lastName} | [USES 10 UNITS PER NAME] Infer the likely country of origin of a personal name. Assumes names as they are in the country of origin. For US, CA, AU, NZ and other melting-pots : use &#39;diaspora&#39; instead.
*PersonalApi* | [**originBatch**](docs/Api/PersonalApi.md#originbatch) | **POST** /api2/json/originBatch | [USES 10 UNITS PER NAME] Infer the likely country of origin of up to 100 names, detecting automatically the cultural context.
*PersonalApi* | [**originFull**](docs/Api/PersonalApi.md#originfull) | **GET** /api2/json/originFull/{personalNameFull} | [USES 10 UNITS PER NAME] Infer the likely country of origin of a personal name. Assumes names as they are in the country of origin. For US, CA, AU, NZ and other melting-pots : use &#39;diaspora&#39; instead.
*PersonalApi* | [**originFullBatch**](docs/Api/PersonalApi.md#originfullbatch) | **POST** /api2/json/originFullBatch | [USES 10 UNITS PER NAME] Infer the likely country of origin of up to 100 names, detecting automatically the cultural context.
*PersonalApi* | [**parseName**](docs/Api/PersonalApi.md#parsename) | **GET** /api2/json/parseName/{nameFull} | Infer the likely first/last name structure of a name, ex. John Smith or SMITH, John or SMITH; John.
*PersonalApi* | [**parseNameBatch**](docs/Api/PersonalApi.md#parsenamebatch) | **POST** /api2/json/parseNameBatch | Infer the likely first/last name structure of a name, ex. John Smith or SMITH, John or SMITH; John.
*PersonalApi* | [**parseNameGeo**](docs/Api/PersonalApi.md#parsenamegeo) | **GET** /api2/json/parseName/{nameFull}/{countryIso2} | Infer the likely first/last name structure of a name, ex. John Smith or SMITH, John or SMITH; John. For better accuracy, provide a geographic context.
*PersonalApi* | [**parseNameGeoBatch**](docs/Api/PersonalApi.md#parsenamegeobatch) | **POST** /api2/json/parseNameGeoBatch | Infer the likely first/last name structure of a name, ex. John Smith or SMITH, John or SMITH; John. Giving a local context improves precision.
*PersonalApi* | [**religion2**](docs/Api/PersonalApi.md#religion2) | **GET** /api2/json/religion/{countryIso2}/{subDivisionIso31662}/{firstName}/{lastName} | [USES 10 UNITS PER NAME] Infer the likely religion of a personal first/last name. NB: only for INDIA (as of current version).
*PersonalApi* | [**religionBatch**](docs/Api/PersonalApi.md#religionbatch) | **POST** /api2/json/religionBatch | [USES 10 UNITS PER NAME] Infer the likely religion of up to 100 personal first/last names. NB: only for India as of currently.
*PersonalApi* | [**religionFull**](docs/Api/PersonalApi.md#religionfull) | **GET** /api2/json/religionFull/{countryIso2}/{subDivisionIso31662}/{personalNameFull} | [USES 10 UNITS PER NAME] Infer the likely religion of a personal full name. NB: only for INDIA (as of current version).
*PersonalApi* | [**religionFullBatch**](docs/Api/PersonalApi.md#religionfullbatch) | **POST** /api2/json/religionFullBatch | [USES 10 UNITS PER NAME] Infer the likely religion of up to 100 personal full names. NB: only for India as of currently.
*PersonalApi* | [**subclassification**](docs/Api/PersonalApi.md#subclassification) | **GET** /api2/json/subclassification/{countryIso2}/{firstName}/{lastName} | [USES 10 UNITS PER NAME] Infer the likely origin of a name at a country subclassification level (state or regeion). Initially, this is only supported for India (ISO2 code &#39;IN&#39;).
*PersonalApi* | [**subclassificationBatch**](docs/Api/PersonalApi.md#subclassificationbatch) | **POST** /api2/json/subclassificationBatch | [USES 10 UNITS PER NAME] Infer the likely origin of a list of up to 100 names at a country subclassification level (state or regeion). Initially, this is only supported for India (ISO2 code &#39;IN&#39;).
*PersonalApi* | [**subclassificationFull**](docs/Api/PersonalApi.md#subclassificationfull) | **GET** /api2/json/subclassificationFull/{countryIso2}/{fullName} | [USES 10 UNITS PER NAME] Infer the likely origin of a name at a country subclassification level (state or regeion). Initially, this is only supported for India (ISO2 code &#39;IN&#39;).
*PersonalApi* | [**subclassificationFullBatch**](docs/Api/PersonalApi.md#subclassificationfullbatch) | **POST** /api2/json/subclassificationFullBatch | [USES 10 UNITS PER NAME] Infer the likely origin of a list of up to 100 names at a country subclassification level (state or regeion). Initially, this is only supported for India (ISO2 code &#39;IN&#39;).
*PersonalApi* | [**usRaceEthnicity**](docs/Api/PersonalApi.md#usraceethnicity) | **GET** /api2/json/usRaceEthnicity/{firstName}/{lastName} | [USES 10 UNITS PER NAME] Infer a US resident&#39;s likely race/ethnicity according to US Census taxonomy W_NL (white, non latino), HL (hispano latino),  A (asian, non latino), B_NL (black, non latino). Optionally add header X-OPTION-USRACEETHNICITY-TAXONOMY: USRACEETHNICITY-6CLASSES for two additional classes, AI_AN (American Indian or Alaskan Native) and PI (Pacific Islander).
*PersonalApi* | [**usRaceEthnicityBatch**](docs/Api/PersonalApi.md#usraceethnicitybatch) | **POST** /api2/json/usRaceEthnicityBatch | [USES 10 UNITS PER NAME] Infer up-to 100 US resident&#39;s likely race/ethnicity according to US Census taxonomy. Output is W_NL (white, non latino), HL (hispano latino),  A (asian, non latino), B_NL (black, non latino). Optionally add header X-OPTION-USRACEETHNICITY-TAXONOMY: USRACEETHNICITY-6CLASSES for two additional classes, AI_AN (American Indian or Alaskan Native) and PI (Pacific Islander).
*PersonalApi* | [**usRaceEthnicityFull**](docs/Api/PersonalApi.md#usraceethnicityfull) | **GET** /api2/json/usRaceEthnicityFull/{personalNameFull} | [USES 10 UNITS PER NAME] Infer a US resident&#39;s likely race/ethnicity according to US Census taxonomy W_NL (white, non latino), HL (hispano latino),  A (asian, non latino), B_NL (black, non latino). Optionally add header X-OPTION-USRACEETHNICITY-TAXONOMY: USRACEETHNICITY-6CLASSES for two additional classes, AI_AN (American Indian or Alaskan Native) and PI (Pacific Islander).
*PersonalApi* | [**usRaceEthnicityFullBatch**](docs/Api/PersonalApi.md#usraceethnicityfullbatch) | **POST** /api2/json/usRaceEthnicityFullBatch | [USES 10 UNITS PER NAME] Infer up-to 100 US resident&#39;s likely race/ethnicity according to US Census taxonomy. Output is W_NL (white, non latino), HL (hispano latino),  A (asian, non latino), B_NL (black, non latino). Optionally add header X-OPTION-USRACEETHNICITY-TAXONOMY: USRACEETHNICITY-6CLASSES for two additional classes, AI_AN (American Indian or Alaskan Native) and PI (Pacific Islander).
*PersonalApi* | [**usRaceEthnicityZIP5**](docs/Api/PersonalApi.md#usraceethnicityzip5) | **GET** /api2/json/usRaceEthnicityZIP5/{firstName}/{lastName}/{zip5Code} | [USES 10 UNITS PER NAME] Infer a US resident&#39;s likely race/ethnicity according to US Census taxonomy, using (optional) ZIP5 code info. Output is W_NL (white, non latino), HL (hispano latino),  A (asian, non latino), B_NL (black, non latino). Optionally add header X-OPTION-USRACEETHNICITY-TAXONOMY: USRACEETHNICITY-6CLASSES for two additional classes, AI_AN (American Indian or Alaskan Native) and PI (Pacific Islander).
*PersonalApi* | [**usZipRaceEthnicityBatch**](docs/Api/PersonalApi.md#uszipraceethnicitybatch) | **POST** /api2/json/usZipRaceEthnicityBatch | [USES 10 UNITS PER NAME] Infer up-to 100 US resident&#39;s likely race/ethnicity according to US Census taxonomy, with (optional) ZIP code. Output is W_NL (white, non latino), HL (hispano latino),  A (asian, non latino), B_NL (black, non latino). Optionally add header X-OPTION-USRACEETHNICITY-TAXONOMY: USRACEETHNICITY-6CLASSES for two additional classes, AI_AN (American Indian or Alaskan Native) and PI (Pacific Islander).
*SocialApi* | [**phoneCode**](docs/Api/SocialApi.md#phonecode) | **GET** /api2/json/phoneCode/{firstName}/{lastName}/{phoneNumber} | [USES 11 UNITS PER NAME] Infer the likely country and phone prefix, given a personal name and formatted / unformatted phone number.
*SocialApi* | [**phoneCodeBatch**](docs/Api/SocialApi.md#phonecodebatch) | **POST** /api2/json/phoneCodeBatch | [USES 11 UNITS PER NAME] Infer the likely country and phone prefix, of up to 100 personal names, detecting automatically the local context given a name and formatted / unformatted phone number.
*SocialApi* | [**phoneCodeGeo**](docs/Api/SocialApi.md#phonecodegeo) | **GET** /api2/json/phoneCodeGeo/{firstName}/{lastName}/{phoneNumber}/{countryIso2} | [USES 11 UNITS PER NAME] Infer the likely phone prefix, given a personal name and formatted / unformatted phone number, with a local context (ISO2 country of residence).
*SocialApi* | [**phoneCodeGeoBatch**](docs/Api/SocialApi.md#phonecodegeobatch) | **POST** /api2/json/phoneCodeGeoBatch | [USES 11 UNITS PER NAME] Infer the likely country and phone prefix, of up to 100 personal names, with a local context (ISO2 country of residence).
*SocialApi* | [**phoneCodeGeoFeedbackLoop**](docs/Api/SocialApi.md#phonecodegeofeedbackloop) | **GET** /api2/json/phoneCodeGeoFeedbackLoop/{firstName}/{lastName}/{phoneNumber}/{phoneNumberE164}/{countryIso2} | [CREDITS 1 UNIT] Feedback loop to better infer the likely phone prefix, given a personal name and formatted / unformatted phone number, with a local context (ISO2 country of residence).

## Models

- [APIBillingPeriodUsageOut](docs/Model/APIBillingPeriodUsageOut.md)
- [APIClassifierOut](docs/Model/APIClassifierOut.md)
- [APIClassifierTaxonomyOut](docs/Model/APIClassifierTaxonomyOut.md)
- [APIClassifiersStatusOut](docs/Model/APIClassifiersStatusOut.md)
- [APICounterV2Out](docs/Model/APICounterV2Out.md)
- [APIKeyOut](docs/Model/APIKeyOut.md)
- [APIPeriodUsageOut](docs/Model/APIPeriodUsageOut.md)
- [APIPlanSubscriptionOut](docs/Model/APIPlanSubscriptionOut.md)
- [APIServiceOut](docs/Model/APIServiceOut.md)
- [APIServicesOut](docs/Model/APIServicesOut.md)
- [APIUsageAggregatedOut](docs/Model/APIUsageAggregatedOut.md)
- [APIUsageHistoryOut](docs/Model/APIUsageHistoryOut.md)
- [BatchCommunityEngageFullOut](docs/Model/BatchCommunityEngageFullOut.md)
- [BatchCommunityEngageOut](docs/Model/BatchCommunityEngageOut.md)
- [BatchCorridorIn](docs/Model/BatchCorridorIn.md)
- [BatchCorridorOut](docs/Model/BatchCorridorOut.md)
- [BatchFirstLastNameCasteOut](docs/Model/BatchFirstLastNameCasteOut.md)
- [BatchFirstLastNameCastegroupOut](docs/Model/BatchFirstLastNameCastegroupOut.md)
- [BatchFirstLastNameDiasporaedOut](docs/Model/BatchFirstLastNameDiasporaedOut.md)
- [BatchFirstLastNameGenderIn](docs/Model/BatchFirstLastNameGenderIn.md)
- [BatchFirstLastNameGenderedOut](docs/Model/BatchFirstLastNameGenderedOut.md)
- [BatchFirstLastNameGeoIn](docs/Model/BatchFirstLastNameGeoIn.md)
- [BatchFirstLastNameGeoOut](docs/Model/BatchFirstLastNameGeoOut.md)
- [BatchFirstLastNameGeoSubclassificationOut](docs/Model/BatchFirstLastNameGeoSubclassificationOut.md)
- [BatchFirstLastNameGeoSubdivisionIn](docs/Model/BatchFirstLastNameGeoSubdivisionIn.md)
- [BatchFirstLastNameGeoZippedIn](docs/Model/BatchFirstLastNameGeoZippedIn.md)
- [BatchFirstLastNameIn](docs/Model/BatchFirstLastNameIn.md)
- [BatchFirstLastNameOriginedOut](docs/Model/BatchFirstLastNameOriginedOut.md)
- [BatchFirstLastNamePhoneCodedOut](docs/Model/BatchFirstLastNamePhoneCodedOut.md)
- [BatchFirstLastNamePhoneNumberGeoIn](docs/Model/BatchFirstLastNamePhoneNumberGeoIn.md)
- [BatchFirstLastNamePhoneNumberIn](docs/Model/BatchFirstLastNamePhoneNumberIn.md)
- [BatchFirstLastNameReligionedOut](docs/Model/BatchFirstLastNameReligionedOut.md)
- [BatchFirstLastNameSubdivisionIn](docs/Model/BatchFirstLastNameSubdivisionIn.md)
- [BatchFirstLastNameUSRaceEthnicityOut](docs/Model/BatchFirstLastNameUSRaceEthnicityOut.md)
- [BatchMatchPersonalFirstLastNameIn](docs/Model/BatchMatchPersonalFirstLastNameIn.md)
- [BatchNameGeoIn](docs/Model/BatchNameGeoIn.md)
- [BatchNameIn](docs/Model/BatchNameIn.md)
- [BatchNameMatchCandidatesOut](docs/Model/BatchNameMatchCandidatesOut.md)
- [BatchNameMatchedOut](docs/Model/BatchNameMatchedOut.md)
- [BatchPersonalNameCastegroupOut](docs/Model/BatchPersonalNameCastegroupOut.md)
- [BatchPersonalNameDiasporaedOut](docs/Model/BatchPersonalNameDiasporaedOut.md)
- [BatchPersonalNameGenderedOut](docs/Model/BatchPersonalNameGenderedOut.md)
- [BatchPersonalNameGeoIn](docs/Model/BatchPersonalNameGeoIn.md)
- [BatchPersonalNameGeoOut](docs/Model/BatchPersonalNameGeoOut.md)
- [BatchPersonalNameGeoSubclassificationOut](docs/Model/BatchPersonalNameGeoSubclassificationOut.md)
- [BatchPersonalNameGeoSubdivisionIn](docs/Model/BatchPersonalNameGeoSubdivisionIn.md)
- [BatchPersonalNameIn](docs/Model/BatchPersonalNameIn.md)
- [BatchPersonalNameOriginedOut](docs/Model/BatchPersonalNameOriginedOut.md)
- [BatchPersonalNameParsedOut](docs/Model/BatchPersonalNameParsedOut.md)
- [BatchPersonalNameReligionedOut](docs/Model/BatchPersonalNameReligionedOut.md)
- [BatchPersonalNameSubdivisionIn](docs/Model/BatchPersonalNameSubdivisionIn.md)
- [BatchPersonalNameUSRaceEthnicityOut](docs/Model/BatchPersonalNameUSRaceEthnicityOut.md)
- [BatchProperNounCategorizedOut](docs/Model/BatchProperNounCategorizedOut.md)
- [CommunityEngageOptionOut](docs/Model/CommunityEngageOptionOut.md)
- [CommunityEngageOut](docs/Model/CommunityEngageOut.md)
- [CorridorIn](docs/Model/CorridorIn.md)
- [CorridorOut](docs/Model/CorridorOut.md)
- [FeedbackLoopOut](docs/Model/FeedbackLoopOut.md)
- [FirstLastNameCasteOut](docs/Model/FirstLastNameCasteOut.md)
- [FirstLastNameCastegroupOut](docs/Model/FirstLastNameCastegroupOut.md)
- [FirstLastNameDiasporaedOut](docs/Model/FirstLastNameDiasporaedOut.md)
- [FirstLastNameGenderIn](docs/Model/FirstLastNameGenderIn.md)
- [FirstLastNameGenderedOut](docs/Model/FirstLastNameGenderedOut.md)
- [FirstLastNameGeoIn](docs/Model/FirstLastNameGeoIn.md)
- [FirstLastNameGeoOut](docs/Model/FirstLastNameGeoOut.md)
- [FirstLastNameGeoSubclassificationOut](docs/Model/FirstLastNameGeoSubclassificationOut.md)
- [FirstLastNameGeoSubdivisionIn](docs/Model/FirstLastNameGeoSubdivisionIn.md)
- [FirstLastNameGeoZippedIn](docs/Model/FirstLastNameGeoZippedIn.md)
- [FirstLastNameIn](docs/Model/FirstLastNameIn.md)
- [FirstLastNameOriginedOut](docs/Model/FirstLastNameOriginedOut.md)
- [FirstLastNameOut](docs/Model/FirstLastNameOut.md)
- [FirstLastNamePhoneCodedOut](docs/Model/FirstLastNamePhoneCodedOut.md)
- [FirstLastNamePhoneNumberGeoIn](docs/Model/FirstLastNamePhoneNumberGeoIn.md)
- [FirstLastNamePhoneNumberIn](docs/Model/FirstLastNamePhoneNumberIn.md)
- [FirstLastNameReligionedOut](docs/Model/FirstLastNameReligionedOut.md)
- [FirstLastNameSubdivisionIn](docs/Model/FirstLastNameSubdivisionIn.md)
- [FirstLastNameUSRaceEthnicityOut](docs/Model/FirstLastNameUSRaceEthnicityOut.md)
- [MatchPersonalFirstLastNameIn](docs/Model/MatchPersonalFirstLastNameIn.md)
- [NameGeoIn](docs/Model/NameGeoIn.md)
- [NameIn](docs/Model/NameIn.md)
- [NameMatchCandidateOut](docs/Model/NameMatchCandidateOut.md)
- [NameMatchCandidatesOut](docs/Model/NameMatchCandidatesOut.md)
- [NameMatchedOut](docs/Model/NameMatchedOut.md)
- [PersonalNameCastegroupOut](docs/Model/PersonalNameCastegroupOut.md)
- [PersonalNameDiasporaedOut](docs/Model/PersonalNameDiasporaedOut.md)
- [PersonalNameGenderedOut](docs/Model/PersonalNameGenderedOut.md)
- [PersonalNameGeoIn](docs/Model/PersonalNameGeoIn.md)
- [PersonalNameGeoOut](docs/Model/PersonalNameGeoOut.md)
- [PersonalNameGeoSubclassificationOut](docs/Model/PersonalNameGeoSubclassificationOut.md)
- [PersonalNameGeoSubdivisionIn](docs/Model/PersonalNameGeoSubdivisionIn.md)
- [PersonalNameIn](docs/Model/PersonalNameIn.md)
- [PersonalNameOriginedOut](docs/Model/PersonalNameOriginedOut.md)
- [PersonalNameParsedOut](docs/Model/PersonalNameParsedOut.md)
- [PersonalNameReligionedOut](docs/Model/PersonalNameReligionedOut.md)
- [PersonalNameSubdivisionIn](docs/Model/PersonalNameSubdivisionIn.md)
- [PersonalNameUSRaceEthnicityOut](docs/Model/PersonalNameUSRaceEthnicityOut.md)
- [ProperNounCategorizedOut](docs/Model/ProperNounCategorizedOut.md)
- [RegionISO](docs/Model/RegionISO.md)
- [RegionOut](docs/Model/RegionOut.md)
- [ReligionStatOut](docs/Model/ReligionStatOut.md)
- [SoftwareVersionOut](docs/Model/SoftwareVersionOut.md)

## Authorization

Authentication schemes defined for the API:
### api_key

- **Type**: API key
- **API key parameter name**: X-API-KEY
- **Location**: HTTP header


## Tests

To run the tests, use:

```bash
composer install
vendor/bin/phpunit
```

## Author

contact@namsor.com

## About this package

This PHP package is automatically generated by the [OpenAPI Generator](https://openapi-generator.tech) project:

- API version: `2.0.29`
    - Package version: `1.0.0`
    - Generator version: `7.11.0`
- Build package: `org.openapitools.codegen.languages.PhpClientCodegen`
