require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

new_member_form_1 = LaunchDarklyClient::NewMemberForm.new
new_member_form_1.email = "sandy@acme.com"
new_member_form_1.password = "***"
new_member_form_1.first_name = "Ariel"
new_member_form_1.last_name = "Flores"
new_member_form_1.role = "reader"
new_member_form_1.custom_roles = [
    "customRole1",
    "customRole2",
]
new_member_form_1.team_keys = [
    "team-1",
    "team-2",
]
new_member_form_1.role_attributes = nil

new_member_form = [
    new_member_form_1,
]

begin
    response = LaunchDarklyClient::AccountMembersApi.new.post_members(
        new_member_form,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling AccountMembersApi#post_members: #{e}"
end
