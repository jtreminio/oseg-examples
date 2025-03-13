require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["X-API-KEY"] = "YOUR_API_KEY"
end

begin
    response = NamsorClient::PersonalApi.new.community_engage(
        "GB", # country_iso2
        "Ada", # first_name
        "Lovelace", # last_name
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling PersonalApi#community_engage: #{e}"
end
