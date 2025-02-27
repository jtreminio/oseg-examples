require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["api_key"] = "YOUR_API_KEY"
end

begin
    response = NamsorClient::PersonalApi.new.subclassification_full(
        "NG", # country_iso2
        "Jannat Rahmani", # full_name
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling PersonalApi#subclassification_full: #{e}"
end
