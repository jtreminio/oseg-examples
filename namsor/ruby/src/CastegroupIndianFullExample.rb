require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["api_key"] = "YOUR_API_KEY"
end

begin
    response = NamsorClient::IndianApi.new.castegroup_indian_full(
        "IN-UP", # sub_division_iso31662
        "Akash Sharma", # personal_name_full
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling IndianApi#castegroup_indian_full: #{e}"
end
