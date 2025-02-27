require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["api_key"] = "YOUR_API_KEY"
end

begin
    response = NamsorClient::PersonalApi.new.gender_geo(
        "Keith", # first_name
        "Haring", # last_name
        "US", # country_iso2
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling PersonalApi#gender_geo: #{e}"
end
