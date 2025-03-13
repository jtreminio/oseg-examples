require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["X-API-KEY"] = "YOUR_API_KEY"
end

personal_names_1 = NamsorClient::PersonalNameGeoIn.new
personal_names_1.id = "0d7d6417-0bbb-4205-951d-b3473f605b56"
personal_names_1.name = "Keith Haring"
personal_names_1.country_iso2 = "US"

personal_names = [
    personal_names_1,
]

batch_personal_name_geo_in = NamsorClient::BatchPersonalNameGeoIn.new
batch_personal_name_geo_in.personal_names = personal_names

begin
    response = NamsorClient::PersonalApi.new.diaspora_full_batch(
        {
            batch_personal_name_geo_in: batch_personal_name_geo_in,
        },
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling PersonalApi#diaspora_full_batch: #{e}"
end
