import json
from datetime import date, datetime
from pprint import pprint

from namsor_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"api_key": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    corridor_from_to_1_first_last_name_geo_from = models.FirstLastNameGeoIn(
        id="e630dda5-13b3-42c5-8f1d-648aa8a21c42",
        firstName="Ada",
        lastName="Lovelace",
        countryIso2="GB",
    )

    corridor_from_to_1_first_last_name_geo_to = models.FirstLastNameGeoIn(
        id="e630dda5-13b3-42c5-8f1d-648aa8a21c42",
        firstName="Nicolas",
        lastName="Tesla",
        countryIso2="US",
    )

    corridor_from_to_1 = models.CorridorIn(
        id="e630dda5-13b3-42c5-8f1d-648aa8a21c42",
        firstLastNameGeoFrom=corridor_from_to_1_first_last_name_geo_from,
        firstLastNameGeoTo=corridor_from_to_1_first_last_name_geo_to,
    )

    corridor_from_to = [
        corridor_from_to_1,
    ]

    batch_corridor_in = models.BatchCorridorIn(
        corridorFromTo=corridor_from_to,
    )

    try:
        response = api.PersonalApi(api_client).corridor_batch(
            batch_corridor_in=batch_corridor_in,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling PersonalApi#corridor_batch: %s\n" % e)
