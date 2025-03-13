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
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class GenderJapaneseNamePinyinBatchExample
{
    fun genderJapaneseNamePinyinBatch()
    {
        ApiClient.apiKey["X-API-KEY"] = "YOUR_API_KEY"

        val personalNames1 = FirstLastNameIn(
            id = "id",
            firstName = "firstName",
            lastName = "lastName",
        )

        val personalNames2 = FirstLastNameIn(
            id = "id",
            firstName = "firstName",
            lastName = "lastName",
        )

        val personalNames = arrayListOf<FirstLastNameIn>(
            personalNames1,
            personalNames2,
        )

        val batchFirstLastNameIn = BatchFirstLastNameIn(
            personalNames = personalNames,
        )

        try
        {
            val response = JapaneseApi().genderJapaneseNamePinyinBatch(
                batchFirstLastNameIn = batchFirstLastNameIn,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling JapaneseApi#genderJapaneseNamePinyinBatch")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling JapaneseApi#genderJapaneseNamePinyinBatch")
            e.printStackTrace()
        }
    }
}
