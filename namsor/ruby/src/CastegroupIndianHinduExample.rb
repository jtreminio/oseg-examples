require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["X-API-KEY"] = "YOUR_API_KEY"
end

begin
    response = NamsorClient::IndianApi.new.castegroup_indian_hindu(
        "IN-UP", # sub_division_iso31662
        "Akash", # first_name
        "Sharma", # last_name
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling IndianApi#castegroup_indian_hindu: #{e}"
end
