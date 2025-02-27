require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["api_key"] = "YOUR_API_KEY"
end

personal_names_1 = NamsorClient::PersonalNameGeoIn.new
personal_names_1.id = "3a2d203a-a6a4-42f9-acd1-1b5c56c7d39f"
personal_names_1.name = "Keith Haring"
personal_names_1.country_iso2 = "US"

personal_names = [
    personal_names_1,
]

batch_personal_name_geo_in = NamsorClient::BatchPersonalNameGeoIn.new
batch_personal_name_geo_in.personal_names = personal_names

begin
    response = NamsorClient::PersonalApi.new.gender_full_geo_batch(
        {
            batch_personal_name_geo_in: batch_personal_name_geo_in,
        },
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling PersonalApi#gender_full_geo_batch: #{e}"
end
