import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    new_member_form_1 = models.NewMemberForm(
        email="sandy@acme.com",
        password="***",
        firstName="Ariel",
        lastName="Flores",
        role="reader",
        customRoles=[
            "customRole1",
            "customRole2",
        ],
        teamKeys=[
            "team-1",
            "team-2",
        ],
        roleAttributes=None,
    )

    new_member_form = [
        new_member_form_1,
    ]

    try:
        response = api.AccountMembersApi(api_client).post_members(
            new_member_form=new_member_form,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling AccountMembersApi#post_members: %s\n" % e)
