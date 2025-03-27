import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
)

with ApiClient(configuration) as api_client:
    try:
        api.CSATSurveyPageApi(api_client).get_csat_survey_page(
            conversation_uuid=0,
        )
    except ApiException as e:
        print("Exception when calling CSATSurveyPageApi#get_csat_survey_page: %s\n" % e)
