package oseg.launchdarkly_examples

import com.launchdarkly.client.infrastructure.*
import com.launchdarkly.client.apis.*
import com.launchdarkly.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class EvaluateContextInstanceExample
{
    fun evaluateContextInstance()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        try
        {
            val response = ContextsApi().evaluateContextInstance(
                projectKey = "projectKey_string",
                environmentKey = "environmentKey_string",
                requestBody = Serializer.moshi.adapter<Map<String, Any>>().fromJson("""
                    {
                        "key": "user-key-123abc",
                        "kind": "user",
                        "otherAttribute": "other attribute value"
                    }
                """)!!,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ContextsApi#evaluateContextInstance")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ContextsApi#evaluateContextInstance")
            e.printStackTrace()
        }
    }
}
