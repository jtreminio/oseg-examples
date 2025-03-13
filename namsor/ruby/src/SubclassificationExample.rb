require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["X-API-KEY"] = "YOUR_API_KEY"
end

begin
    response = NamsorClient::PersonalApi.new.subclassification(
        "NG", # country_iso2
        "Jannat", # first_name
        "Rahmani", # last_name
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling PersonalApi#subclassification: #{e}"
end
