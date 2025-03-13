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
class ReligionIndianBatchExample
{
    fun religionIndianBatch()
    {
        ApiClient.apiKey["X-API-KEY"] = "YOUR_API_KEY"

        val personalNames1 = FirstLastNameSubdivisionIn(
            id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
            firstName = "Akash",
            lastName = "Sharma",
            subdivisionIso = "IN-PB",
        )

        val personalNames = arrayListOf<FirstLastNameSubdivisionIn>(
            personalNames1,
        )

        val batchFirstLastNameSubdivisionIn = BatchFirstLastNameSubdivisionIn(
            personalNames = personalNames,
        )

        try
        {
            val response = IndianApi().religionIndianBatch(
                batchFirstLastNameSubdivisionIn = batchFirstLastNameSubdivisionIn,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling IndianApi#religionIndianBatch")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling IndianApi#religionIndianBatch")
            e.printStackTrace()
        }
    }
}
