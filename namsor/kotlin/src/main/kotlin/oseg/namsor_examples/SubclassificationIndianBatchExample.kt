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
class SubclassificationIndianBatchExample
{
    fun subclassificationIndianBatch()
    {
        ApiClient.apiKey["api_key"] = "YOUR_API_KEY"

        val personalNames1 = FirstLastNameGeoIn(
            id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
            firstName = "Jannat",
            lastName = "Rahmani",
        )

        val personalNames = arrayListOf<FirstLastNameGeoIn>(
            personalNames1,
        )

        val batchFirstLastNameGeoIn = BatchFirstLastNameGeoIn(
            personalNames = personalNames,
        )

        try
        {
            val response = IndianApi().subclassificationIndianBatch(
                batchFirstLastNameGeoIn = batchFirstLastNameGeoIn,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling IndianApi#subclassificationIndianBatch")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling IndianApi#subclassificationIndianBatch")
            e.printStackTrace()
        }
    }
}
