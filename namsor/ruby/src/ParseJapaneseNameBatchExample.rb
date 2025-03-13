require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["X-API-KEY"] = "YOUR_API_KEY"
end

personal_names_1 = NamsorClient::PersonalNameIn.new
personal_names_1.id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42"
personal_names_1.name = "小島 秀夫"

personal_names = [
    personal_names_1,
]

batch_personal_name_in = NamsorClient::BatchPersonalNameIn.new
batch_personal_name_in.personal_names = personal_names

begin
    response = NamsorClient::JapaneseApi.new.parse_japanese_name_batch(
        {
            batch_personal_name_in: batch_personal_name_in,
        },
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling JapaneseApi#parse_japanese_name_batch: #{e}"
end
