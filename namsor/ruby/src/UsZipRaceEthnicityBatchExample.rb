require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["api_key"] = "YOUR_API_KEY"
end

personal_names_1 = NamsorClient::FirstLastNameGeoZippedIn.new
personal_names_1.id = "728767f9-c5b2-4ed3-a071-828077f16552"
personal_names_1.first_name = "Keith"
personal_names_1.last_name = "Haring"
personal_names_1.country_iso2 = "US"
personal_names_1.zip_code = "10019"

personal_names = [
    personal_names_1,
]

batch_first_last_name_geo_zipped_in = NamsorClient::BatchFirstLastNameGeoZippedIn.new
batch_first_last_name_geo_zipped_in.personal_names = personal_names

begin
    response = NamsorClient::PersonalApi.new.us_zip_race_ethnicity_batch(
        {
            batch_first_last_name_geo_zipped_in: batch_first_last_name_geo_zipped_in,
        },
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling PersonalApi#us_zip_race_ethnicity_batch: #{e}"
end
