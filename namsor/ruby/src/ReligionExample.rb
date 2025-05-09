require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["X-API-KEY"] = "YOUR_API_KEY"
end

begin
    response = NamsorClient::IndianApi.new.religion(
        "IN-UP", # sub_division_iso31662
        "Akash Sharma", # personal_name_full
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling IndianApi#religion: #{e}"
end
