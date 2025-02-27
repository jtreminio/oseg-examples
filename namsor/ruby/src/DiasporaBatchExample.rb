require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["api_key"] = "YOUR_API_KEY"
end

personal_names_1 = NamsorClient::FirstLastNameGeoIn.new
personal_names_1.id = "0d7d6417-0bbb-4205-951d-b3473f605b56"
personal_names_1.first_name = "Keith"
personal_names_1.last_name = "Haring"
personal_names_1.country_iso2 = "US"

personal_names = [
    personal_names_1,
]

batch_first_last_name_geo_in = NamsorClient::BatchFirstLastNameGeoIn.new
batch_first_last_name_geo_in.personal_names = personal_names

begin
    response = NamsorClient::PersonalApi.new.diaspora_batch(
        {
            batch_first_last_name_geo_in: batch_first_last_name_geo_in,
        },
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling PersonalApi#diaspora_batch: #{e}"
end
