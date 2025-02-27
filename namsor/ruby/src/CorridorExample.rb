require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["api_key"] = "YOUR_API_KEY"
end

begin
    response = NamsorClient::PersonalApi.new.corridor(
        "GB", # country_iso2_from
        "Ada", # first_name_from
        "Lovelace", # last_name_from
        "US", # country_iso2_to
        "Nicolas", # first_name_to
        "Tesla", # last_name_to
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling PersonalApi#corridor: #{e}"
end
