import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        api.FlagImportConfigurationsBetaApi(api_client).trigger_flag_import_job(
            project_key=None,
            integration_key=None,
            integration_id=None,
        )
    except ApiException as e:
        print("Exception when calling FlagImportConfigurationsBetaApi#trigger_flag_import_job: %s\n" % e)
