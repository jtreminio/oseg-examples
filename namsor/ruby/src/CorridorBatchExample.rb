require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["X-API-KEY"] = "YOUR_API_KEY"
end

corridor_from_to_1_first_last_name_geo_from = NamsorClient::FirstLastNameGeoIn.new
corridor_from_to_1_first_last_name_geo_from.id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42"
corridor_from_to_1_first_last_name_geo_from.first_name = "Ada"
corridor_from_to_1_first_last_name_geo_from.last_name = "Lovelace"
corridor_from_to_1_first_last_name_geo_from.country_iso2 = "GB"

corridor_from_to_1_first_last_name_geo_to = NamsorClient::FirstLastNameGeoIn.new
corridor_from_to_1_first_last_name_geo_to.id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42"
corridor_from_to_1_first_last_name_geo_to.first_name = "Nicolas"
corridor_from_to_1_first_last_name_geo_to.last_name = "Tesla"
corridor_from_to_1_first_last_name_geo_to.country_iso2 = "US"

corridor_from_to_1 = NamsorClient::CorridorIn.new
corridor_from_to_1.id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42"
corridor_from_to_1.first_last_name_geo_from = corridor_from_to_1_first_last_name_geo_from
corridor_from_to_1.first_last_name_geo_to = corridor_from_to_1_first_last_name_geo_to

corridor_from_to = [
    corridor_from_to_1,
]

batch_corridor_in = NamsorClient::BatchCorridorIn.new
batch_corridor_in.corridor_from_to = corridor_from_to

begin
    response = NamsorClient::PersonalApi.new.corridor_batch(
        {
            batch_corridor_in: batch_corridor_in,
        },
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling PersonalApi#corridor_batch: #{e}"
end
