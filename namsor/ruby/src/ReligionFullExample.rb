require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["api_key"] = "YOUR_API_KEY"
end

begin
    response = NamsorClient::PersonalApi.new.religion_full(
        "NG", # country_iso2
        "IN-UP", # sub_division_iso31662
        "Akash Sharma", # personal_name_full
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling PersonalApi#religion_full: #{e}"
end
