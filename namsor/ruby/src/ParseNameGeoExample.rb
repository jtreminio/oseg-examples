require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["X-API-KEY"] = "YOUR_API_KEY"
end

begin
    response = NamsorClient::PersonalApi.new.parse_name_geo(
        "Ricardo Darín", # name_full
        "AR", # country_iso2
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling PersonalApi#parse_name_geo: #{e}"
end
