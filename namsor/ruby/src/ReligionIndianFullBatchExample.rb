require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["X-API-KEY"] = "YOUR_API_KEY"
end

personal_names_1 = NamsorClient::PersonalNameSubdivisionIn.new
personal_names_1.id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42"
personal_names_1.name = "Akash Sharma"
personal_names_1.subdivision_iso = "IN-PB"

personal_names = [
    personal_names_1,
]

batch_personal_name_subdivision_in = NamsorClient::BatchPersonalNameSubdivisionIn.new
batch_personal_name_subdivision_in.personal_names = personal_names

begin
    response = NamsorClient::IndianApi.new.religion_indian_full_batch(
        {
            batch_personal_name_subdivision_in: batch_personal_name_subdivision_in,
        },
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling IndianApi#religion_indian_full_batch: #{e}"
end
