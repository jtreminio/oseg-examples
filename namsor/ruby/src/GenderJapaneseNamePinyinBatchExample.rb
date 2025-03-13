require "json"
require "namsor_client"

NamsorClient.configure do |config|
    config.api_key["X-API-KEY"] = "YOUR_API_KEY"
end

personal_names_1 = NamsorClient::FirstLastNameIn.new
personal_names_1.id = "id"
personal_names_1.first_name = "firstName"
personal_names_1.last_name = "lastName"

personal_names_2 = NamsorClient::FirstLastNameIn.new
personal_names_2.id = "id"
personal_names_2.first_name = "firstName"
personal_names_2.last_name = "lastName"

personal_names = [
    personal_names_1,
    personal_names_2,
]

batch_first_last_name_in = NamsorClient::BatchFirstLastNameIn.new
batch_first_last_name_in.personal_names = personal_names

begin
    response = NamsorClient::JapaneseApi.new.gender_japanese_name_pinyin_batch(
        {
            batch_first_last_name_in: batch_first_last_name_in,
        },
    )

    p response
rescue NamsorClient::ApiError => e
    puts "Exception when calling JapaneseApi#gender_japanese_name_pinyin_batch: #{e}"
end
