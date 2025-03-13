require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["X-API-KEY"] = "YOUR_API_KEY"
end

personal_names_1 = NamsorClient::PersonalNameGeoSubdivisionIn.new
personal_names_1.id = "id"
personal_names_1.name = "name"
personal_names_1.country_iso2 = "countryIso2"
personal_names_1.subdivision_iso = "subdivisionIso"

personal_names_2 = NamsorClient::PersonalNameGeoSubdivisionIn.new
personal_names_2.id = "id"
personal_names_2.name = "name"
personal_names_2.country_iso2 = "countryIso2"
personal_names_2.subdivision_iso = "subdivisionIso"

personal_names = [
    personal_names_1,
    personal_names_2,
]

batch_personal_name_geo_subdivision_in = NamsorClient::BatchPersonalNameGeoSubdivisionIn.new
batch_personal_name_geo_subdivision_in.personal_names = personal_names

begin
    response = NamsorClient::PersonalApi.new.religion_full_batch(
        {
            batch_personal_name_geo_subdivision_in: batch_personal_name_geo_subdivision_in,
        },
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling PersonalApi#religion_full_batch: #{e}"
end
