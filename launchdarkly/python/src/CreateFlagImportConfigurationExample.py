import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    flag_import_configuration_post = models.FlagImportConfigurationPost(
        config=json.loads("""
            {
                "environmentId": "The ID of the environment in the external system",
                "ldApiKey": "An API key with create flag permissions in your LaunchDarkly account",
                "ldMaintainer": "The ID of the member who will be the maintainer of the imported flags",
                "ldTag": "A tag to apply to all flags imported to LaunchDarkly",
                "splitTag": "If provided, imports only the flags from the external system with this tag. Leave blank to import all flags.",
                "workspaceApiKey": "An API key with read permissions in the external feature management system",
                "workspaceId": "The ID of the workspace in the external system"
            }
        """),
        name="Sample configuration",
        tags=[
            "example-tag",
        ],
    )

    try:
        response = api.FlagImportConfigurationsBetaApi(api_client).create_flag_import_configuration(
            project_key=None,
            integration_key=None,
            flag_import_configuration_post=flag_import_configuration_post,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling FlagImportConfigurationsBetaApi#create_flag_import_configuration: %s\n" % e)
