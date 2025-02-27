import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    randomization_units_1 = models.RandomizationUnitInput(
        randomizationUnit="user",
        standardRandomizationUnit="organization",
    )

    randomization_units = [
        randomization_units_1,
    ]

    randomization_settings_put = models.RandomizationSettingsPut(
        randomizationUnits=randomization_units,
    )

    try:
        response = api.ExperimentsApi(api_client).put_experimentation_settings(
            project_key="the-project-key",
            randomization_settings_put=randomization_settings_put,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ExperimentsApi#put_experimentation_settings: %s\n" % e)
