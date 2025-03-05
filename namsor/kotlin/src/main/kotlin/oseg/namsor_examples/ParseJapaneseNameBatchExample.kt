package oseg.namsor_examples

import app.namsor.client.infrastructure.*
import app.namsor.client.apis.*
import app.namsor.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map

class ParseJapaneseNameBatchExample
{
    fun parseJapaneseNameBatch()
    {
        ApiClient.apiKey["api_key"] = "YOUR_API_KEY"

        val personalNames1 = PersonalNameIn(
            id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
            name = "小島 秀夫",
        )

        val personalNames = arrayListOf<PersonalNameIn>(
            personalNames1,
        )

        val batchPersonalNameIn = BatchPersonalNameIn(
            personalNames = personalNames,
        )

        try
        {
            val response = JapaneseApi().parseJapaneseNameBatch(
                batchPersonalNameIn = batchPersonalNameIn,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling JapaneseApi#parseJapaneseNameBatch")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling JapaneseApi#parseJapaneseNameBatch")
            e.printStackTrace()
        }
    }
}
