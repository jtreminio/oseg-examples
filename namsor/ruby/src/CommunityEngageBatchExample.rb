require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["api_key"] = "YOUR_API_KEY"
end

personal_names_1 = NamsorClient::FirstLastNameGeoIn.new
personal_names_1.id = "id"
personal_names_1.first_name = "firstName"
personal_names_1.last_name = "lastName"
personal_names_1.country_iso2 = "countryIso2"

personal_names_2 = NamsorClient::FirstLastNameGeoIn.new
personal_names_2.id = "id"
personal_names_2.first_name = "firstName"
personal_names_2.last_name = "lastName"
personal_names_2.country_iso2 = "countryIso2"

personal_names = [
    personal_names_1,
    personal_names_2,
]

batch_first_last_name_geo_in = NamsorClient::BatchFirstLastNameGeoIn.new
batch_first_last_name_geo_in.personal_names = personal_names

begin
    response = NamsorClient::PersonalApi.new.community_engage_batch(
        {
            batch_first_last_name_geo_in: batch_first_last_name_geo_in,
        },
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling PersonalApi#community_engage_batch: #{e}"
end
