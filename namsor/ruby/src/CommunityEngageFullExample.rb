require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["api_key"] = "YOUR_API_KEY"
end

begin
    response = NamsorClient::PersonalApi.new.community_engage_full(
        "GB", # country_iso2
        "Ada Lovelace", # personal_name_full
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling PersonalApi#community_engage_full: #{e}"
end
