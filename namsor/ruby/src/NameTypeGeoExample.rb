require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["api_key"] = "YOUR_API_KEY"
end

begin
    response = NamsorClient::GeneralApi.new.name_type_geo(
        "Edi Gathegi", # proper_noun
        "KE", # country_iso2
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling GeneralApi#name_type_geo: #{e}"
end
