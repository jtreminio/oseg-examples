require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["api_key"] = "YOUR_API_KEY"
end

personal_names_with_phone_numbers_1 = NamsorClient::FirstLastNamePhoneNumberGeoIn.new
personal_names_with_phone_numbers_1.id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42"
personal_names_with_phone_numbers_1.first_name = "Teniola"
personal_names_with_phone_numbers_1.last_name = "Apata"
personal_names_with_phone_numbers_1.phone_number = "08186472651"
personal_names_with_phone_numbers_1.country_iso2 = "NG"
personal_names_with_phone_numbers_1.country_iso2_alt = "CI"

personal_names_with_phone_numbers = [
    personal_names_with_phone_numbers_1,
]

batch_first_last_name_phone_number_geo_in = NamsorClient::BatchFirstLastNamePhoneNumberGeoIn.new
batch_first_last_name_phone_number_geo_in.personal_names_with_phone_numbers = personal_names_with_phone_numbers

begin
    response = NamsorClient::SocialApi.new.phone_code_geo_batch(
        {
            batch_first_last_name_phone_number_geo_in: batch_first_last_name_phone_number_geo_in,
        },
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling SocialApi#phone_code_geo_batch: #{e}"
end
