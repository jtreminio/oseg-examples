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

class ReligionIndianFullBatchExample
{
    fun religionIndianFullBatch()
    {
        ApiClient.apiKey["api_key"] = "YOUR_API_KEY"

        val personalNames1 = PersonalNameSubdivisionIn(
            id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
            name = "Akash Sharma",
            subdivisionIso = "IN-PB",
        )

        val personalNames = arrayListOf<PersonalNameSubdivisionIn>(
            personalNames1,
        )

        val batchPersonalNameSubdivisionIn = BatchPersonalNameSubdivisionIn(
            personalNames = personalNames,
        )

        try
        {
            val response = IndianApi().religionIndianFullBatch(
                batchPersonalNameSubdivisionIn = batchPersonalNameSubdivisionIn,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling IndianApi#religionIndianFullBatch")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling IndianApi#religionIndianFullBatch")
            e.printStackTrace()
        }
    }
}
