require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["X-API-KEY"] = "YOUR_API_KEY"
end

personal_names_1 = NamsorClient::FirstLastNameGeoIn.new
personal_names_1.id = "85dd5f48-b9e1-4019-88ce-ccc7e56b763f"
personal_names_1.first_name = "Keith"
personal_names_1.last_name = "Haring"
personal_names_1.country_iso2 = "US"

personal_names = [
    personal_names_1,
]

batch_first_last_name_geo_in = NamsorClient::BatchFirstLastNameGeoIn.new
batch_first_last_name_geo_in.personal_names = personal_names

begin
    response = NamsorClient::PersonalApi.new.us_race_ethnicity_batch(
        {
            batch_first_last_name_geo_in: batch_first_last_name_geo_in,
        },
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling PersonalApi#us_race_ethnicity_batch: #{e}"
end
