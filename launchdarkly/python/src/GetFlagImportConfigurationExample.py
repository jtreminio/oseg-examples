import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.FlagImportConfigurationsBetaApi(api_client).get_flag_import_configuration(
            project_key="projectKey_string",
            integration_key="integrationKey_string",
            integration_id="integrationId_string",
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling FlagImportConfigurationsBetaApi#get_flag_import_configuration: %s\n" % e)
